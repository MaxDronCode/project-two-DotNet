using Store.Repository.Entities;

namespace Store.Repository;

public interface IClientRepository
{
    IEnumerable<ClientEntity> GetAllClients();
}