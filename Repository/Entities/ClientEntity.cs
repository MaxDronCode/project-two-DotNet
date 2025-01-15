using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Repository.Entities;

[Table("clients")]
public class ClientEntity
{

    [Key]
    [Column("id")]
    [StringLength(36)]
    [Required]
    public string Id { get; set; }
    
    [Column("nif")]
    [StringLength(10, MinimumLength = 9)]
    [Required]
    public string Nif { get; set; }
    
    [Column("name")]
    [StringLength(150, MinimumLength = 2)]
    [Required]
    public string Name { get; set; }
    
    [Column("address")]
    [StringLength(150, MinimumLength = 5)]
    public string? Address { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null | GetType() != obj.GetType())
        {
            return false;
        }
        var other = (ClientEntity) obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    
    
}