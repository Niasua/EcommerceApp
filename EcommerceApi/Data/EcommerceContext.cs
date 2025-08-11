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
            .HasForeignKey(sp => sp.SaleId);

        // Soft Delete
        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.isDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(c => !c.isDeleted);
        modelBuilder.Entity<Sale>().HasQueryFilter(s => !s.isDeleted);
    }
}
