namespace Store.Domain.Models;

public class SaleCabDomain
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public List<SaleDetDomain> Details { get; set; }
}