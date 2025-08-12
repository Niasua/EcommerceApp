using EcommerceApi.Data;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories;

public class SaleProductRepository : ISaleProductRepository
{
    private readonly EcommerceContext _context;
    public SaleProductRepository(EcommerceContext context)
    {
        _context = context;
    }

    public async Task AddAsync(SaleProduct saleProduct)
    {
        await _context.SaleProducts.AddAsync(saleProduct);
        await _context.SaveChangesAsync();
    }

    public async Task<SaleProduct> GetByIdsAsync(int saleId, int productId)
    {
        return await _context.SaleProducts
            .FirstOrDefaultAsync(sp => sp.SaleId == saleId && sp.ProductId == productId);
    }

    public async Task<IEnumerable<SaleProduct>> GetByProductIdAsync(int productId)
    {
        return await _context.SaleProducts
            .Where(sp => sp.ProductId == productId && !sp.Product.isDeleted && !sp.Sale.isDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<SaleProduct>> GetBySaleIdAsync(int saleId)
    {
        return await _context.SaleProducts
            .Where(sp => sp.SaleId == saleId && !sp.Product.isDeleted && !sp.Sale.isDeleted)
            .ToListAsync();
    }

    public async Task UpdateAsync(SaleProduct saleProduct)
    {
        _context.SaleProducts.Update(saleProduct);
        await _context.SaveChangesAsync();
    }
}
