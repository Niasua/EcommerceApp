using EcommerceApi.Data;
using EcommerceApi.Models;
using EcommerceApi.Repositories;
using SQLitePCL;

namespace EcommerceApi.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _repo;
    public SaleService(ISaleRepository repo)
    {
        _repo = repo;
    }

    public async Task AddSaleAsync(Sale sale)
    {
        await _repo.AddAsync(sale);
    }

    public async Task DeleteSaleAsync(int id)
    {
        var sale = await _repo.GetByIdAsync(id);
        if (sale == null)
            throw new Exception("Sale not found.");

        await _repo.SoftDeleteAsync(sale);
    }

    public async Task<Sale> GetSaleByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<Sale> GetSaleByIdWithDetailsAsync(int id)
    {
        return await _repo.GetByIdWithDetailsAsync(id);
    }

    public async Task<(IEnumerable<Sale> sales, int totalCount)> GetSalesPagedAsync(int pageNumber, int pageSize)
    {
        var sales = await _repo.GetSalesAsync(pageNumber, pageSize);
        var totalCount = await _repo.GetTotalCountAsync();
        return (sales, totalCount);
    }

    public async Task UpdateSaleAsync(Sale sale)
    {
        var existing = await _repo.GetByIdAsync(sale.Id);
        if (existing == null)
            throw new Exception("Sale not found.");

        existing.DateTime = sale.DateTime;

        await _repo.UpdateAsync(existing);
    }
}
