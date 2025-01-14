using Store.Domain.Models;

namespace Store.Domain.Services.Interfaces;

public interface IClientService
{
    IEnumerable<ClientDomain> GetAllClients();
    
    Task<ClientDomain> GetClientById(Guid id);
    
    Task<ClientDomain> CreateClient(ClientDomain clientDomain);
}