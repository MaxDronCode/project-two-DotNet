using Store.Domain.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Client;
using Store.Repository.Interfaces;

namespace Store.Domain.Services.Implementations;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public IEnumerable<ClientDomain> GetAllClients()
    {
        var clients =  clientRepository.GetAllClients();
        return clients.Select(client => client.ToDomain());
    }

    public async Task<ClientDomain> GetClientById(Guid id)
    {
        Console.WriteLine($"Parsed id to guid from the service: {id}");
        var client = await clientRepository.GetClientById(id.ToString());

        if (client == null)
        {
            throw new ClientNotFoundException($"Client with id {id} not found.");
        }

        return client.ToDomain();
    }

    public async Task<ClientDomain> CreateClient(ClientDomain clientDomain)
    {
        var clientNifAlreadyExists = clientRepository.DoesClientNifExist(clientDomain.Nif);
        
        if (clientNifAlreadyExists)
        {
            throw new ClientAlreadyExistsException($"Client with NIF {clientDomain.Nif} already exists.");
        }
        
        clientDomain.Id = Guid.NewGuid();
        
        var createdClient = await clientRepository.CreateClient(clientDomain.ToEntity());

        return createdClient.ToDomain();
    }
}