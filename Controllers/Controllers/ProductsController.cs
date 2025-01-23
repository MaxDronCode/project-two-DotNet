using Microsoft.AspNetCore.Mvc;
using Store.Controllers.Dtos.Product;
using Store.Controllers.Mappers;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Product;

namespace Store.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponseDto>> GetAllProducts()
    {
        var productsDomain = productService.GetAllProducts();

        var productsDto = productsDomain.Select(product => product.ToDto());
        
        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetProductById(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest("Invalid id format.");
        }
        
        try
        {
            var productDomain = await productService.GetProductById(Guid.Parse(id));
            return Ok(productDomain.ToDto());
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponseDto>> CreateProduct(ProductRequestDto productRequestDto)
    {
        try
        {
            var createdProduct = await productService.CreateProduct(productRequestDto.ToDomain());
            return Ok(createdProduct.ToDto());
        }
        catch (ProductAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponseDto>> UpdateProduct(string id, ProductRequestDto productRequestDto)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest("Invalid id format.");
        }
        
        try
        {
            var productDomain = await productService.UpdateProduct(Guid.Parse(id), productRequestDto.ToDomain());
            return Ok(productDomain.ToDto());
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ProductAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        // TODO return 422 if product has sales
        if (!Guid.TryParse(id, out var _))
        {
            return BadRequest("Invalid id format.");
        }

        try
        {
            await productService.DeleteProduct(Guid.Parse(id));
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
        
        return NoContent();
    }

    [HttpGet("{id}/stock")]
    public async Task<ActionResult<ProductStockResponseDto>> GetProductStock(string id)
    {
        if (!Guid.TryParse(id, out var _))
        {
            return BadRequest("Invalid id format,");
        }

        try
        {
            var productStock = await productService.GetProductStock(Guid.Parse(id));
            return Ok(productStock.ToDto());
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}