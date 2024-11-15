using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categories
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        // GET: Categories/Details/5
        public Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            var category = _unitOfWork.Category.Get(c => c.Id == id);

            return Task.FromResult<IActionResult>(View(category));
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
            }
            return Task.FromResult<IActionResult>(View(category));
        }

        // GET: Categories/Edit/5
        public Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            var category = _unitOfWork.Category.Get(c => c.Id == id);

            return Task.FromResult<IActionResult>(View(category));
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(category);
            try
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(category.Id))
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

        // GET: Categories/Delete/5
        public Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            var category = _unitOfWork.Category.Get(c => c.Id == id);

            return Task.FromResult<IActionResult>(View(category));
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = _unitOfWork.Category.Get(c => c.Id == id);
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
        }

        private Task<bool> CategoryExists(int id)
        {
            return Task.FromResult(_unitOfWork.Category.GetAll().Any(c => c.Id == id));
        }
    }
}
