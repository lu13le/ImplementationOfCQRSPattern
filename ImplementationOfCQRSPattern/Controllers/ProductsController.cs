using ImplementationOfCQRSPattern.Commands;
using ImplementationOfCQRSPattern.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImplementationOfCQRSPattern.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductCommandHandler _productCommandHandler;
    private readonly IProductQueryHandler _productQueryHandler;

    public ProductsController(IProductCommandHandler productCommandHandler, IProductQueryHandler productQueryHandler)
    {
        _productCommandHandler =
            productCommandHandler ?? throw new ArgumentNullException(nameof(productCommandHandler));
        _productQueryHandler = productQueryHandler ?? throw new ArgumentNullException(nameof(productQueryHandler));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        await _productCommandHandler.Handle(command);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
    {
        command.Id = id;
        await _productCommandHandler.Handle(command);
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productQueryHandler.GetById(id);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productQueryHandler.GetAll();
        return Ok(products);
    }
}