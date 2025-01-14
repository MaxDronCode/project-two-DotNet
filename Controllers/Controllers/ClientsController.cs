using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos;
using Store.Controllers.Mappers;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Client;

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

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientResponseDto>> GetClientById(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest("Invalid id format.");
        }
        
        try
        {
            var clientDomain = await clientService.GetClientById(Guid.Parse(id));
            return Ok(clientDomain.ToDto());
        }
        catch (ClientNotFoundException e)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<ClientResponseDto>> CreateClient(ClientRequestDto clientRequestDto)
    {
        try
        {
            var createdClientDomain = await clientService.CreateClient(clientRequestDto.ToDomain());
            return CreatedAtAction(nameof(GetClientById), new { id = createdClientDomain.Id }, createdClientDomain.ToDto());
        }
        catch (ClientAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
}