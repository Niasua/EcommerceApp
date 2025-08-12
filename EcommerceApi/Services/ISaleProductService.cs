using EcommerceApi.Models;

namespace EcommerceApi.Services;

public interface ISaleProductService
{
    Task<IEnumerable<SaleProduct>> GetSaleProductsByProductIdAsync(int id);
    Task<IEnumerable<SaleProduct>> GetSaleProductsBySaleIdAsync(int id);
    Task<SaleProduct> GetSaleProductByIdsAsync(int saleId, int productId);
    Task AddSaleProductAsync(SaleProduct SaleProduct);
    Task UpdateSaleProductAsync(SaleProduct SaleProduct);
}
