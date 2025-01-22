namespace Store.Domain.Models;

public class PastSalesResponseDomain
{
    public Guid Id { get; set; }
    public List<ProductInSaleDomain> Products { get; set; }
}