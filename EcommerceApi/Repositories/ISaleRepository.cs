using EcommerceApi.Models;

namespace EcommerceApi.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetSalesAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> GetByIdWithDetailsAsync(int id);
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task SoftDeleteAsync(Sale sale);
    }
}
