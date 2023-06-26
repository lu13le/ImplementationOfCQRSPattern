using ImplementationOfCQRSPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace ImplementationOfCQRSPattern.DbContext;

public class ProductsDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
    {
    }

    public DbSet<Product>? Products { get; set; }
}