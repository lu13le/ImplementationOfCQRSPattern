using ImplementationOfCQRSPattern.Models;

namespace ImplementationOfCQRSPattern.Handlers.Interfaces;

public interface IProductQueryHandler
{
    Task<Product?> GetById(int id);
    Task<IEnumerable<Product>> GetAll();
}