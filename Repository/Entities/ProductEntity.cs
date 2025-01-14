using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Repository.Entities;

[Table("products")]
public class ProductEntity
{
    [Key]
    [Column("id")]
    [StringLength(36)]
    [Required]
    public string Id { get; set; }

    [Column("code")]
    [StringLength(10, MinimumLength = 5)]
    [Required]
    public string Code { get; set; }

    [Column("name")]
    [StringLength(100, MinimumLength = 2)]
    [Required]
    public string Name { get; set; }

    [Column("stock")]
    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}