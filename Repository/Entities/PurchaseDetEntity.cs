using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Repository.Entities;

public class PurchaseDetEntity
{
    [StringLength(36, MinimumLength = 36)]
    [Column("purchase_id")]
    public string PurchaseId { get; set; }

    [StringLength(36, MinimumLength = 36)]
    [Column("product_id")]
    public string ProductId { get; set; }

    [Range(0, int.MaxValue)] public int Quantity { get; set; }
}