using Store.Domain.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Client;
using Store.Exceptions.Product;
using Store.Repository.Interfaces;

namespace Store.Domain.Services.Implementations;

public class ClientService(IClientRepository clientRepository, IProductRepository productRepository) : IClientService
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
        var clientNifAlreadyExists = await clientRepository.DoesClientNifExist(clientDomain.Nif);
        
        if (clientNifAlreadyExists)
        {
            throw new ClientAlreadyExistsException($"Client with NIF {clientDomain.Nif} already exists.");
        }
        
        clientDomain.Id = Guid.NewGuid();
        
        var createdClient = await clientRepository.CreateClient(clientDomain.ToEntity());

        return createdClient.ToDomain();
    }

    public async Task<ClientDomain> UpdateClient(Guid id, ClientDomain clientDomain)
    {
        var existingEntity = await clientRepository.GetClientById(id.ToString());
        
        if (existingEntity == null)
        {
            throw new ClientNotFoundException($"Client with id {id} not found.");
        }
        
        existingEntity.Name = clientDomain.Name;
        existingEntity.Nif = clientDomain.Nif;
        existingEntity.Address = clientDomain.Address;

        var updatedClient = await clientRepository.UpdateClient(existingEntity);
        
        return updatedClient.ToDomain();


    }

    public async Task DeleteClient(Guid id)
    {
        var existingClient = await clientRepository.GetClientById(id.ToString());
        
        if (existingClient == null)
        {
            throw new ClientNotFoundException($"Client with id {id} not found.");
        }
        
        // Check if client has sales
        var clientHasPastSales = await clientRepository.DoesClientHaveSales(id.ToString());
        
        if (clientHasPastSales)
        {
            throw new ClientHasPastSalesException($"Client with id {id} has past sales.");
        }
        
        await clientRepository.DeleteClient(existingClient);
    }

    public async Task<List<PastSalesResponseDomain>> GetPastSalesOfAClient(Guid clientId)
    {
        var existingClient = await clientRepository.GetClientById(clientId.ToString());

        if (existingClient == null)
            throw new ClientNotFoundException($"Client with id {clientId} not found.");
        
        
        var pastSales = await clientRepository.GetPastSalesOfAClient(clientId.ToString());

        var sales = new List<PastSalesResponseDomain>();

        foreach (var pastSale in pastSales)
        {
            var pastSaleResponseDomain = new PastSalesResponseDomain();

            pastSaleResponseDomain.Id = Guid.Parse(pastSale.Id);
            
            var productsInSaleDomainList = new List<ProductInSaleDomain>();

            foreach (var saleDetEntity in pastSale.Details)
            {
                var productId = saleDetEntity.ProductId;
                var productEntity = await productRepository.GetProductById(productId);
                if (productEntity == null)
                {
                    throw new ProductNotFoundException($"Product with id {productId} not found.");
                }
                var productName = productEntity.Name;
                var singleProductInSaleDomain = new SingleProductInSaleDomain
                {
                    Id = Guid.Parse(productId),
                    Name = productName
                };
                
                var productInSaleDomain = new ProductInSaleDomain
                {
                    Product = singleProductInSaleDomain,
                    Quantity = saleDetEntity.Quantity
                };
                
                productsInSaleDomainList.Add(productInSaleDomain);
            }
            
            pastSaleResponseDomain.Products = productsInSaleDomainList;
            sales.Add(pastSaleResponseDomain);
        }
        
        
        return sales;
    }
}