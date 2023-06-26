using ImplementationOfCQRSPattern.DbContext;
using ImplementationOfCQRSPattern.Handlers.Interfaces;
using ImplementationOfCQRSPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace ImplementationOfCQRSPattern.Handlers;

public class ProductQueryHandler : IProductQueryHandler
{
    private readonly ProductsDbContext _productDbContext;

    public ProductQueryHandler(ProductsDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task<Product?> GetById(int id)
    {
        return await _productDbContext.FindAsync<Product>(id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _productDbContext.Products!.ToListAsync();
    }
}