using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Store.Controllers.Dtos.Purchase;

public class PurchaseRequestDto
{
    [Required]
    public string Supplier { get; set; }
    
    [NotNull]
    public List<ProductToPurchase> Products { get; set; }
}