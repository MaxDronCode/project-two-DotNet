using Store.Domain.Models;
using Store.Repository.Entities;

namespace Store.Domain.Mappers;

public static class ClientMapper
{
    public static ClientDomain ToDomain(this ClientEntity entity)
    {
        var domain = new ClientDomain
        {
            Id = Guid.Parse(entity.Id),
            Name = entity.Name,
            Nif = entity.Nif,
            Address = entity.Address
        };

        return domain;
    }

    public static ClientEntity ToEntity(this ClientDomain domain)
    {
        var entity = new ClientEntity
        {
            Id = domain.Id.ToString(),
            Name = domain.Name,
            Nif = domain.Nif,
            Address = domain.Address
        };

        return entity;
    }
}