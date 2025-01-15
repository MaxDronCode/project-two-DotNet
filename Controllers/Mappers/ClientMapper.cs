using Store.Controllers.Dtos;
using Store.Controllers.Dtos.Client;
using Store.Domain.Models;

namespace Store.Controllers.Mappers;

public static class ClientMapper
{
    public static ClientResponseDto ToDto(this ClientDomain domain)
    {
        var dto = new ClientResponseDto
        {
            Id = domain.Id.ToString(),
            Name = domain.Name,
            Nif = domain.Nif,
            Address = domain.Address
        };

        return dto;
    }

    public static ClientDomain ToDomain(this ClientRequestDto dto)
    {
        var domain = new ClientDomain
        {
            Nif = dto.Nif,
            Name = dto.Name,
            Address = dto.Address
        };

        return domain;
    }
}