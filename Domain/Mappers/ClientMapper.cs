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
}