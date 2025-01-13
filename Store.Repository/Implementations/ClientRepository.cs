using Microsoft.EntityFrameworkCore;
using Store.Repository.dbConfig;
using Store.Repository.Entities;

namespace Store.Repository.Implementations;

public class ClientRepository(AppDbContext context) : IClientRepository
{
    public IEnumerable<ClientEntity> GetAllClients()
    {
        return context.Clients;
    }
}