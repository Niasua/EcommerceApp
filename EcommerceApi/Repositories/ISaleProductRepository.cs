using EcommerceApi.Models;

namespace EcommerceApi.Repositories;

public interface ISaleProductRepository
{
    Task<IEnumerable<SaleProduct>> GetBySaleIdAsync(int saleId);
    Task<IEnumerable<SaleProduct>> GetByProductIdAsync(int productId);
    Task<SaleProduct> GetByIdsAsync(int saleId, int productId);
    Task AddAsync(SaleProduct saleProduct);
    Task UpdateAsync(SaleProduct saleProduct);
}
