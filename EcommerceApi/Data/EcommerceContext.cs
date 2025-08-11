using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data;

public class EcommerceContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }

    public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite Key
        modelBuilder.Entity<SaleProduct>()
            .HasKey(sp => new { sp.SaleId, sp.ProductId });

        // Sale -> SaleProducts
        modelBuilder.Entity<SaleProduct>()
            .HasOne(sp => sp.Sale)
            .WithMany(s => s.SaleProducts)
            .HasForeignKey(sp => sp.SaleId);

        // Product -> SaleProducts
        modelBuilder.Entity<SaleProduct>()
            .HasOne(sp => sp.Product)
            .WithMany(p => p.SaleProducts)
            .HasForeignKey(sp => sp.ProductId);

        // Soft Delete
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.isDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(c => !c.isDeleted);
        modelBuilder.Entity<Sale>().HasQueryFilter(s => !s.isDeleted);
        modelBuilder.Entity<SaleProduct>().HasQueryFilter(sp => !sp.Product.isDeleted);

        // Seed - Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics", isDeleted = false },
            new Category { Id = 2, Name = "Clothing", isDeleted = false },
            new Category { Id = 3, Name = "Home", isDeleted = false }
        );

        // Seed - Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Smartphone", Price = 500.00m, CategoryId = 1, isDeleted = false },
            new Product { Id = 2, Name = "Headphones", Price = 50.00m, CategoryId = 1, isDeleted = false },
            new Product { Id = 3, Name = "T-Shirt", Price = 20.00m, CategoryId = 2, isDeleted = false },
            new Product { Id = 4, Name = "Jeans", Price = 40.00m, CategoryId = 2, isDeleted = false },
            new Product { Id = 5, Name = "Coffee Maker", Price = 80.00m, CategoryId = 3, isDeleted = false }
        );

        // Seed - Sales (FECHAS FIJAS)
        modelBuilder.Entity<Sale>().HasData(
            new Sale { Id = 1, DateTime = new DateTime(2025, 8, 1, 10, 0, 0), isDeleted = false },
            new Sale { Id = 2, DateTime = new DateTime(2025, 8, 5, 15, 30, 0), isDeleted = false }
        );

        // Seed - SaleProduct (Many-to-Many with extra fields)
        modelBuilder.Entity<SaleProduct>().HasData(
            new SaleProduct { SaleId = 1, ProductId = 1, Quantity = 1, UnitPrice = 500.00m },
            new SaleProduct { SaleId = 1, ProductId = 2, Quantity = 2, UnitPrice = 50.00m },
            new SaleProduct { SaleId = 2, ProductId = 3, Quantity = 3, UnitPrice = 20.00m },
            new SaleProduct { SaleId = 2, ProductId = 5, Quantity = 1, UnitPrice = 80.00m }
        );
    }
}
