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

    public async Task<ClientEntity> CreateClient(ClientEntity clientEntity)
    {
        context.Clients.Add(clientEntity);
        await context.SaveChangesAsync();
        return clientEntity;
    }

    public Task<bool> DoesClientNifExist(string nif)
    {
        return Task.FromResult(context.Clients.Any(client => client.Nif == nif));
    }

    public async Task<ClientEntity> UpdateClient(ClientEntity clientEntity)
    {
        context.Clients.Update(clientEntity);
        await context.SaveChangesAsync();
        return clientEntity;
    }
}