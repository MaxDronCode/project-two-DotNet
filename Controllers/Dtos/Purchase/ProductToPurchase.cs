using System.ComponentModel.DataAnnotations;

namespace Store.Controllers.Dtos.Purchase;

public class ProductToPurchase
{
    [Required]
    [StringLength(36, MinimumLength = 36)]
    public string Id { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}