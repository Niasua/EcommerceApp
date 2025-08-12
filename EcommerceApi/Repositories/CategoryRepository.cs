using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly EcommerceContext _context;
    public CategoryRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories
            .FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _context.Categories
            .ToListAsync();
    }

    public async Task SoftDeleteAsync(Category category)
    {
        category.isDeleted = true;
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}
