using EcommerceApi.Models;
using EcommerceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly EcommerceContext _context;
    public ProductRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(int pageNumber, int pageSize)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Products.CountAsync();
    }

    public async Task SoftDeleteAsync(Product product)
    {
        product.isDeleted = true;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        await _context.SaveChangesAsync();
    }
}
