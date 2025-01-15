using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos;
using Store.Controllers.Dtos.Client;
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
            return NotFound(e.Message);
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
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ClientResponseDto>> UpdateClient(string id, ClientRequestDto clientRequestDto)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest("Invalid id format.");
        }
        
        try
        {
            var updatedClientDomain = await clientService.UpdateClient(Guid.Parse(id), clientRequestDto.ToDomain());
            return Ok(updatedClientDomain.ToDto());
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteClient(string id)
    {
        // TODO return 422 if client has sales
        
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest("Invalid id format.");
        }
        
        try
        {
            await clientService.DeleteClient(Guid.Parse(id));
            return NoContent();
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}