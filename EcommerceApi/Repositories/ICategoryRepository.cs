using EcommerceApi.Models;

namespace EcommerceApi.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task SoftDeleteAsync(Category category);
}
