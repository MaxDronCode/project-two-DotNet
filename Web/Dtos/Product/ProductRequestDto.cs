using System.ComponentModel.DataAnnotations;

namespace Store.Controllers.Dtos.Product;

public class ProductRequestDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 5)]
    public string Code { get; set; }
}