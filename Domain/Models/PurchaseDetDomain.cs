namespace Store.Domain.Models;

public class PurchaseDetDomain
{
    public Guid PurchaseId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}