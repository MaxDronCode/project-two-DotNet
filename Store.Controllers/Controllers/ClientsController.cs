using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos;
using Store.Controllers.Mappers;
using Store.Domain.Services.Interfaces;

namespace Store.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ClientResponseDto>> GetAllClients()
    {
        var clientsDomain = clientService.GetAllClients();

        var clientsDto = clientsDomain.Select(client => client.ToDto());
        
        return Ok(clientsDto);
    }
}