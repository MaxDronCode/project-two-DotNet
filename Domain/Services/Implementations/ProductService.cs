using Store.Domain.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Exceptions.Product;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Domain.Services.Implementations;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public IEnumerable<ProductDomain> GetAllProducts()
    {
        var productsEntities = productRepository.GetAllProducts();

        return productsEntities.Select(entity => entity.ToDomain());
    }

    public async Task<ProductDomain> GetProductById(Guid id)
    {
        var productEntity = await productRepository.GetProductById(id.ToString());
        
        if (productEntity == null)
        {
            throw new ProductNotFoundException($"Product with id {id} not found.");
        }

        return productEntity.ToDomain();
    }

    public async Task<ProductDomain> CreateProduct(ProductDomain productDomain)
    {
        var existingProductCode = await productRepository.FindProductByCode(productDomain.Code);
        
        if (existingProductCode != null)
        {
            throw new ProductAlreadyExistsException($"Product with code {productDomain.Code} already exists.");
        }
        
        productDomain.Id = Guid.NewGuid();
        
        var productEntity = await productRepository.CreateProduct(productDomain.ToEntity());
        
        return productEntity.ToDomain();
    }
}