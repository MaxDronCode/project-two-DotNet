﻿using Store.Controllers.Dtos.Sale;
using Store.Domain.Models;

namespace Store.Controllers.Mappers;

public static class SaleMapper
{
    public static SaleRequestDomain ToDomain(this SaleRequestDto dto)
    {
        var domain = new SaleRequestDomain
        {
            Client = dto.Client.ToDomain(),
            Products = dto.Products.ToDomain()
        };

        return domain;

    }

    private static ClientSaleRequestDomain ToDomain(this ClientSaleRequest dto)
    {
        var domain = new ClientSaleRequestDomain
        {
            Id = Guid.Parse(dto.Id)
        };

        return domain;
    }
    
    private static List<ProductSaleRequestDomain> ToDomain(this List<ProductSaleRequest> dtos)
    {
        var domain = dtos.Select(dto => new ProductSaleRequestDomain
        {
            Id = Guid.Parse(dto.Id),
            Quantity = dto.Quantity
        }).ToList();

        return domain;
    }
}