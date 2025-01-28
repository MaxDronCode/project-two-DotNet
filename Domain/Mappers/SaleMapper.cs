using Store.Domain.Models;
using Store.Repository.Entities;

namespace Store.Domain.Mappers;

public static class SaleMapper
{
    public static SaleCabDomain ToDomain(this SaleRequestDomain request)
    {
        var domain = new SaleCabDomain
        {
            ClientId = request.Client.Id,
            Details = request.Products.Select(p => new SaleDetDomain
            {
                Id = p.Id,
                Quantity = p.Quantity
            }).ToList()
        };

        return domain;
    }

    public static SaleCabEntity ToEntity(this SaleCabDomain domain)
    {
        var entity = new SaleCabEntity
        {
            Id = domain.Id.ToString(),
            ClientId = domain.ClientId.ToString(),
            Details = domain.Details.Select(d => new SaleDetEntity
            {
                ProductId = d.Id.ToString(),
                Quantity = d.Quantity,
                SaleId = domain.Id.ToString()
            }).ToList()
        };

        return entity;
    }

    public static List<ProductInSaleDomain> ToDomain(this List<Top5SoldProductsEntity> entities)
    {
        var domains = entities.Select(entity => new ProductInSaleDomain
        {
            Product = new SingleProductInSaleDomain
            {
                Id = Guid.Parse(entity.Id),
                Name = entity.Name
            },
            Quantity = entity.Quantity
        }).ToList();

        return domains;
    }
}