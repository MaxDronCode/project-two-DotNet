using Store.Domain.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Product;
using Store.Repository.Interfaces;

namespace Store.Domain.Services.Implementations;

public class PurchaseService(IPurchaseCabRepository purchaseRepository, IProductRepository productRepository)
    : IPurchaseService
{
    public async Task CreatePurchase(PurchaseRequestDomain purchaseRequestDomain)
    {
        var purchaseCabDomain = purchaseRequestDomain.ToDomain();

        foreach (var detail in purchaseCabDomain.Details)
        {
            // Check if product exists
            var product = await productRepository.GetProductById(detail.ProductId.ToString());

            if (product == null) throw new ProductNotFoundException($"Product with id {detail.ProductId} not found");

            // Update product stock
            product.Stock += detail.Quantity;
            await productRepository.UpdateProduct(product);
        }

        await productRepository.SaveChanges();

        purchaseCabDomain.Id = Guid.NewGuid();

        purchaseCabDomain.Details.ForEach(detail => detail.PurchaseId = purchaseCabDomain.Id);

        await purchaseRepository.CreatePurchase(purchaseCabDomain.ToEntity());
    }
}