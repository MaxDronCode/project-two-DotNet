using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Domain.Services.Mappers;
using Store.Repository;

namespace Store.Domain.Services.Implementations;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public IEnumerable<ClientDomain> GetAllClients()
    {
        var clients =  clientRepository.GetAllClients();
        return clients.Select(client => client.ToDomain());
    }
}