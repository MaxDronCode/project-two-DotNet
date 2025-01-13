using Store.Controllers.Dtos;
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
}