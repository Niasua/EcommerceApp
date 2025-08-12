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
        return (products, totalCount);
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        await _repo.AddAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        var existing = await _repo.GetByIdAsync(product.Id);
        if (existing == null)
            throw new Exception("Product not found");

        existing.Name = product.Name;
        existing.CategoryId = product.CategoryId;

        await _repo.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null)
            throw new Exception("Product not found.");

        await _repo.SoftDeleteAsync(product);
    }
}