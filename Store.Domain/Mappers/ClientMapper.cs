using Store.Domain.Models;
using Store.Repository.Entities;

namespace Store.Domain.Services.Mappers;

public static class ClientMapper
{
    public static ClientDomain ToDomain(this ClientEntity entity)
    {
        var domain = new ClientDomain
        {
            id = entity.id,
            name = entity.name,
            nif = entity.nif,
            address = entity.address
        };

        return domain;
    }
}