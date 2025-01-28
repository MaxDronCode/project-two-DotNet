using System.ComponentModel.DataAnnotations;

namespace Store.Controllers.Dtos.Sale;

public class ClientSaleRequest
{
    [Required]
    [StringLength(36, MinimumLength = 36)]
    public string Id { get; set; }
}