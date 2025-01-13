using Store.Controllers.Dtos;
using Store.Domain.Models;

namespace Store.Controllers.Mappers;

public static class ClientMapper
{
    public static ClientResponseDto ToDto(this ClientDomain domain)
    {
        var dto = new ClientResponseDto
        {
            id = domain.id,
            name = domain.name,
            nif = domain.nif,
            address = domain.address
        };

        return dto;
    }
}