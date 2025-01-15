using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos.Sale;
using Store.Controllers.Mappers;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Client;
using Store.Exceptions.Product;

namespace Store.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController(ISalesService salesService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSale(SaleRequestDto saleRequestDto)
    {
        try
        {
            await salesService.CreateSale(saleRequestDto.ToDomain());
            return Created("Sale created", null);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ProductStockException e)
        {
            return NotFound(e.Message);
        }
    }
}