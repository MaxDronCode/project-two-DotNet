using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Repository.Entities;

public class PurchaseCabEntity
{
    [StringLength(36, MinimumLength = 36)]
    public string Id { get; set; }
    
    public string Supplier { get; set; }

    public List<PurchaseDetEntity> Details { get; set; }
}