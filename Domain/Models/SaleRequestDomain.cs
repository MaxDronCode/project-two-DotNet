namespace Store.Domain.Models;

public class SaleRequestDomain
{
    public ClientSaleRequestDomain Client { get; set; }
    public List<ProductSaleRequestDomain> Products { get; set; }
}