namespace Store.Domain.Models;

public class PurchaseRequestDomain
{
    public string Supplier { get; set; }
    public List<ProductInPurchaseDomain> Products { get; set; }
}