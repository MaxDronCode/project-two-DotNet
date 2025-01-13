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
    public string id { get; set; }
    
    [Column("nif")]
    [StringLength(10, MinimumLength = 9)]
    [Required]
    public string nif { get; set; }
    
    [Column("name")]
    [StringLength(150, MinimumLength = 2)]
    [Required]
    public string name { get; set; }
    
    [Column("address")]
    [StringLength(150, MinimumLength = 5)]
    public string address { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null | GetType() != obj.GetType())
        {
            return false;
        }
        var other = (ClientEntity) obj;
        return id == other.id;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
    
    
    
}