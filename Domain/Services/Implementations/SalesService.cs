using Store.Domain.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Client;
using Store.Exceptions.Product;
using Store.Repository.Interfaces;

namespace Store.Domain.Services.Implementations;

public class SalesService(
    ISalesCabRepository salesCabRepository,
    ISalesDetRepository salesDetRepository,
    IClientRepository clientRepository,
    IProductRepository productRepository) : ISalesService
{
    public async Task CreateSale(SaleRequestDomain saleRequestDomain)
    {
        var saleCabDomain = saleRequestDomain.ToDomain();

        // Check if client exists
        var client = await clientRepository.GetClientById(saleCabDomain.ClientId.ToString());

        if (client == null) throw new ClientNotFoundException($"Client with id {saleCabDomain.ClientId} not found");

        foreach (var detail in saleCabDomain.Details)
        {
            // Check if product exists
            var product = await productRepository.GetProductById(detail.Id.ToString());

            if (product == null) throw new ProductNotFoundException($"Product with id {detail.Id} not found");

            // Check if product has enough stock
            if (product.Stock < detail.Quantity)
                throw new ProductStockException($"Product with id {detail.Id} has not enough stock");

            // Update product stock
            product.Stock -= detail.Quantity;
            await productRepository.UpdateProduct(product);
        }

        await productRepository.SaveChanges();

        saleCabDomain.Id = Guid.NewGuid();

        await salesCabRepository.CreateSale(saleCabDomain.ToEntity());
    }

    public async Task<List<ProductInSaleDomain>> GetTop5SoldProducts()
    {
        var productsEntity = await salesDetRepository.GetTop5SoldProducts();

        return productsEntity.ToDomain();
    }
}