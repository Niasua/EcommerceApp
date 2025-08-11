using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly EcommerceContext _context;
    public SaleRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sale sale)
    {
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task<Sale> GetByIdAsync(int id)
    {
        return await _context.Sales.FindAsync(id);
    }

    public async Task<Sale> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Sales
            .Include(s => s.SaleProducts)
                .ThenInclude(sp => sp.Product)
                    .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Sale>> GetSalesAsync(int pageNumber, int pageSize)
    {
        return await _context.Sales
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Sales.CountAsync();
    }

    public async Task SoftDeleteAsync(Sale sale)
    {
        sale.isDeleted = true;
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sale sale)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync();
    }
}
