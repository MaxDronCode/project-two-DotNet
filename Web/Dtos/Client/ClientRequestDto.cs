using System.ComponentModel.DataAnnotations;

namespace Store.Controllers.Dtos;

public class ClientRequestDto
{
    [Required]
    [StringLength(150, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 9)]
    public string Nif { get; set; }

    [StringLength(150, MinimumLength = 5)] public string? Address { get; set; }
}