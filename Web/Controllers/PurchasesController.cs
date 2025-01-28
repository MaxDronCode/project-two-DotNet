using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos.Purchase;
using Store.Controllers.Mappers;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Product;

namespace Store.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchasesController(IPurchaseService purchaseService) : ControllerBase
{
    public async Task<ActionResult> CreatePurchase(PurchaseRequestDto purchaseRequestDto)
    {
        try
        {
            await purchaseService.CreatePurchase(purchaseRequestDto.ToDomain());
            return Created("Purchase Created", null);
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}