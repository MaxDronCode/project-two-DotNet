using Store.Controllers.Dtos.Purchase;
using Store.Domain.Models;

namespace Store.Controllers.Mappers;

public static class PurchaseMapper
{
    public static PurchaseRequestDomain ToDomain(this PurchaseRequestDto dto)
    {
        return new PurchaseRequestDomain
        {
            Supplier = dto.Supplier,
            Products = dto.Products.Select(product => product.ToDomain()).ToList()
        };
    }

    private static ProductInPurchaseDomain ToDomain(this ProductToPurchase dto)
    {
        return new ProductInPurchaseDomain
        {
            Id = Guid.Parse(dto.Id),
            Quantity = dto.Quantity
        };
    }
}