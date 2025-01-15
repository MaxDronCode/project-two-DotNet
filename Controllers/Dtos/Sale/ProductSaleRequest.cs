using System.ComponentModel.DataAnnotations;

namespace Store.Controllers.Dtos.Sale;

public class ProductSaleRequest
{
    [Required]
    [StringLength(36, MinimumLength = 36)]
    public string Id { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}