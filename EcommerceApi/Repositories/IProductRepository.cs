using EcommerceApi.Models;

namespace EcommerceApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync(int pageNumber, int pageSize);
    Task<int> GetTotalCountAsync();
    Task<Product> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task SoftDeleteAsync(Product product);
}
