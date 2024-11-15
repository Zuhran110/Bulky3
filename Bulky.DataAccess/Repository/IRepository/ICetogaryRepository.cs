using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository;

public interface ICetogaryRepository:IRepository<Category>
{
    void Update(Category Category);
}