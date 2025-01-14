using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos.Product;
using Store.Controllers.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Repository.Interfaces;

namespace Store.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public ActionResult<ProductResponseDto> GetAllProducts(ProductRequestDto productRequestDto)
    {
        var productsDomain = productService.GetAllProducts();

        var productsDto = productsDomain.Select(product => product.ToDto());
        
        return Ok(productsDto);
    }
}