using EcommerceApi.Models;

namespace EcommerceApi.Services;

public interface ISaleService
{
    Task<(IEnumerable<Sale> sales, int totalCount)> GetSalesPagedAsync(int pageNumber, int pageSize);
    Task<Sale> GetSaleByIdAsync(int id);
    Task<Sale> GetSaleByIdWithDetailsAsync(int id);
    Task AddSaleAsync(Sale sale);
    Task UpdateSaleAsync(Sale sale);
    Task DeleteSaleAsync(int id);
}
