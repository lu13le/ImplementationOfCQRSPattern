using ImplementationOfCQRSPattern.Commands;
using ImplementationOfCQRSPattern.DbContext;
using ImplementationOfCQRSPattern.Handlers.Interfaces;
using ImplementationOfCQRSPattern.Models;

namespace ImplementationOfCQRSPattern.Handlers;

public class ProductCommandHandler : IProductCommandHandler
{
    private readonly ProductsDbContext _productDbContext;

    public ProductCommandHandler(ProductsDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task Handle(CreateProductCommand command)
    {
        var newProduct = new Product
        {
            Name = command.Name,
            Price = command.Price
        };

        _productDbContext.Products?.Add(newProduct);
        await _productDbContext.SaveChangesAsync();
    }

    public async Task Handle(UpdateProductCommand command)
    {
        var existingProduct = _productDbContext.Products?.Find(command.Id);
        if (existingProduct == null)
        {
            throw new AggregateException("Product not found");
        }

        existingProduct.Name = command.Name;
        existingProduct.Price = command.Price;
        await _productDbContext.SaveChangesAsync();
    }
}