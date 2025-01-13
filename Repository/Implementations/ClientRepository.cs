using Microsoft.EntityFrameworkCore;
using Store.Repository.dbConfig;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Repository.Implementations;

public class ClientRepository(AppDbContext context) : IClientRepository
{
    public IEnumerable<ClientEntity> GetAllClients()
    {
        return context.Clients;
    }

    public Task<ClientEntity?> GetClientById(string id)
    {
        return context.Clients.FirstOrDefaultAsync(client => client.Id == id);
    }
}