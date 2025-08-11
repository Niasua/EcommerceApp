using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    [Column(TypeName ="decimal(18,2)")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public List<SaleProduct> SaleProducts { get; set; } = new();

    public bool isDeleted { get; set; }
}
