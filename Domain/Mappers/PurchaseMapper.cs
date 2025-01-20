using Store.Domain.Models;
using Store.Repository.Entities;

namespace Store.Domain.Mappers;

public static class PurchaseMapper
{
    public static PurchaseCabDomain ToDomain(this PurchaseRequestDomain requestDomain)
    {
        return new PurchaseCabDomain
        {
            Supplier = requestDomain.Supplier,
            Details = requestDomain.Products.Select(product => product.ToCabDomain()).ToList()
        };
    }

    private static PurchaseDetDomain ToCabDomain(this ProductInPurchaseDomain productInPurchase)
    {
        return new PurchaseDetDomain
        {
            ProductId = productInPurchase.Id,
            Quantity = productInPurchase.Quantity
        };
    }

    public static PurchaseCabEntity ToEntity(this PurchaseCabDomain domain)
    {
        return new PurchaseCabEntity
        {
            Id = domain.Id.ToString(),
            Supplier = domain.Supplier,
            Details = domain.Details.Select(detail => detail.ToEntity()).ToList()
        };
    }

    private static PurchaseDetEntity ToEntity(this PurchaseDetDomain domain)
    {
        return new PurchaseDetEntity
        {
            PurchaseId = domain.PurchaseId.ToString(),
            ProductId = domain.ProductId.ToString(),
            Quantity = domain.Quantity
        };
    }
}