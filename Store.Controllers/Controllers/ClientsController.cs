using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController
{
    [HttpGet]
    public IActionResult<IEnumerable<ClientResponseDto>> GetAllClients()
    {
        
    }
}