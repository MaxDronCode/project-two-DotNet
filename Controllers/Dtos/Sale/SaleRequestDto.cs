using System.ComponentModel.DataAnnotations;
using Store.Domain.Models;

namespace Store.Controllers.Dtos.Sale;

public class SaleRequestDto
{
    [Required]
    public ClientSaleRequest Client { get; set; }
    
    [Required]
    public List<ProductSaleRequest> Products { get; set; }
}