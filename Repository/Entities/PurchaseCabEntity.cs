using System.ComponentModel.DataAnnotations;

namespace Store.Repository.Entities;

public class PurchaseCabEntity
{
    [StringLength(36, MinimumLength = 36)] public string Id { get; set; }

    public string Supplier { get; set; }

    public List<PurchaseDetEntity> Details { get; set; }
}