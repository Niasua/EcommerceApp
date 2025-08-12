using EcommerceApi.Models;
using EcommerceApi.Repositories;

namespace EcommerceApi.Services;

public class SaleProductService : ISaleProductService
{
    private readonly ISaleProductRepository _repo;
    public SaleProductService(ISaleProductRepository repo)
    {
        _repo = repo;
    }

    public async Task AddSaleProductAsync(SaleProduct saleProduct)
    {
        await _repo.AddAsync(saleProduct);
    }

    public async Task<SaleProduct> GetSaleProductByIdsAsync(int saleId, int productId)
    {
        return await _repo.GetByIdsAsync(saleId, productId);
    }

    public async Task<IEnumerable<SaleProduct>> GetSaleProductsByProductIdAsync(int productId)
    {
        return await _repo.GetByProductIdAsync(productId);
    }

    public async Task<IEnumerable<SaleProduct>> GetSaleProductsBySaleIdAsync(int saleId)
    {
        return await _repo.GetBySaleIdAsync(saleId);
    }

    public async Task UpdateSaleProductAsync(SaleProduct saleProduct)
    {
        await _repo.UpdateAsync(saleProduct);
    }
}
