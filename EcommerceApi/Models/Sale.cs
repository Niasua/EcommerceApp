namespace EcommerceApi.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;

    public List<SaleProduct> SaleProducts { get; set; } = new();

    public bool isDeleted { get; set; }
}