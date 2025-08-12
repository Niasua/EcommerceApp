using EcommerceApi.Models;
using EcommerceApi.Repositories;

namespace EcommerceApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<(IEnumerable<Product> products, int totalCount)> GetProductsPagedAsync(int pageNumber, int pageSize)
    {
        var products = await _repo.GetProductsAsync(pageNumber, pageSize);
        var totalCount = await _repo.GetTotalCountAsync();
    }

    public Task<Product> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }
}
