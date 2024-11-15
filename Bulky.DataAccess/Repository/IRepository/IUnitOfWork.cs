namespace Bulky.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICetogaryRepository Category { get; }
    IProductRepository Product { get; }
    void Save();
}