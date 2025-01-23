using Store.Domain.Models;
using Store.Repository.Entities;

namespace Store.Domain.Mappers;

public static class ProductMapper
{
    public static ProductDomain ToDomain(this ProductEntity entity)
    {
        return new ProductDomain
        {
            Id = Guid.Parse(entity.Id),
            Name = entity.Name,
            Code = entity.Code
        };
    } 
    
    public static ProductEntity ToEntity(this ProductDomain domain)
    {
        return new ProductEntity
        {
            Id = domain.Id.ToString(),
            Name = domain.Name,
            Code = domain.Code
        };
    }

    public static ProductStockResponseDomain ToDomain(this ProductStockResponseEntity entity)
    {
        return new ProductStockResponseDomain
        {
            Stock = entity.Stock
        };
    }
}