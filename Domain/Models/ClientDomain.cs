namespace Store.Domain.Models;

public class ClientDomain
{
    public Guid Id { get; set; }
    public string Nif { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}