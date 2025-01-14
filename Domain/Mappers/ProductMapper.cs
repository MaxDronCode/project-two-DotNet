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
    
    
}