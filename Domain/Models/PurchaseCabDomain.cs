namespace Store.Domain.Models;

public class PurchaseCabDomain
{
    public Guid Id { get; set; }
    public string Supplier { get; set; }
    public List<PurchaseDetDomain> Details { get; set; }
}