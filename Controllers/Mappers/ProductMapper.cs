using Store.Controllers.Dtos.Product;
using Store.Domain.Models;

namespace Store.Controllers.Mappers;

public static class ProductMapper
{
    public static ProductResponseDto ToDto(this ProductDomain domain)
    {
        var dto = new ProductResponseDto
        {
            Id = domain.Id.ToString(),
            Name = domain.Name,
            Code = domain.Code
        };

        return dto;
    }
}