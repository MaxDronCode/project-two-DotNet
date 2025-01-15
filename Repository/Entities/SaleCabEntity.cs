using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Repository.Entities;

public class SaleCabEntity
{
    [StringLength(36, MinimumLength = 36)]
    public string Id { get; set; }
    
    [StringLength(36, MinimumLength = 36)]
    [Column("client_id")]
    public string ClientId { get; set; }

    public List<SaleDetEntity> Details { get; set; }
    
}