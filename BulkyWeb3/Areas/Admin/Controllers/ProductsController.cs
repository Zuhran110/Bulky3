using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data;

namespace BulkyWeb3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categories
        public IActionResult Index()
        {
            List<Product> products= _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }

        public Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }
            var products = _unitOfWork.Product.Get(c => c.Id == id);

            return Task.FromResult<IActionResult>(View(products));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> create([Bind("Id,Title,Description,Author,ISBN,ListPrice,Price,Price50,Price100")] Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created successfully!";
                return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
            }
            return Task.FromResult<IActionResult>(View(product));

        }

        // GET: Categories/Edit/5
        public Task<IActionResult> Edit(int? id) {
            if (id == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }
            var product = _unitOfWork.Product.Get(c=>c.Id == id);
            return Task.FromResult<IActionResult> (View(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,ISBN,ListPrice,Price,Price50,Price100")]Product product)
        {
            if(id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid) return View(product);
            try
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "product edited successfully";
            }
            catch (DBConcurrencyException) {
                if (!await ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return Task.FromResult<IActionResult>( NotFound());
            }
            var product = _unitOfWork.Product.Get(c=> c.Id == id);
            return Task.FromResult<IActionResult>(View(product));
        }
        

        [HttpGet, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public Task<IActionResult> Delete(int id) { 
            var product = _unitOfWork.Product.Get(u=>u.Id == id);
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            return Task.FromResult<IActionResult>(RedirectToAction( nameof(Index)));
        }

        private Task<bool> ProductExists(int id)
        {
            return Task.FromResult(_unitOfWork.Product.GetAll().Any(c => c.Id == id));
        }
    }
}
