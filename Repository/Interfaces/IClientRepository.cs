using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface IClientRepository
{
    IEnumerable<ClientEntity> GetAllClients();
    
    Task<ClientEntity?> GetClientById(string id);
    
    Task<ClientEntity> CreateClient(ClientEntity clientEntity);
    
    Task<bool> DoesClientNifExist(string nif);
    
    Task<ClientEntity> UpdateClient(ClientEntity clientEntity);
    
    Task DeleteClient(ClientEntity clientEntity);
    
    Task<bool> DoesClientHaveSales(string clientId);
    
    Task<List<SaleCabEntity>> GetPastSalesOfAClient(string clientId);
}