using EcommerceApi.Data;
using EcommerceApi.Models;
using EcommerceApi.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace EcommerceApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task AddAsync(Category category)
    {
        await _repo.AddAsync(category);
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _repo.GetCategoriesAsync();
    }

    public async Task SoftDeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Category not found");

        await _repo.SoftDeleteAsync(existing);
    }

    public async Task UpdateAsync(Category category)
    {
        await _repo.UpdateAsync(category);
    }
}
