using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface IClientRepository
{
    IEnumerable<ClientEntity> GetAllClients();
    
    Task<ClientEntity?> GetClientById(string id);
}