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

    public async Task<ProductDomain> UpdateProduct(Guid id, ProductDomain productDomain)
    {
        var existingProduct = await productRepository.GetProductById(id.ToString());

        if (existingProduct == null)
        {
            throw new ProductNotFoundException($"Id {id} not found.");
        }
        
        var productCodeAlreadyExists = await productRepository.FindProductByCode(productDomain.Code);
        
        if (productCodeAlreadyExists != null && productCodeAlreadyExists.Id != id.ToString())
        {
            throw new ProductAlreadyExistsException($"Product with code {productDomain.Code} already exists.");
        }

        existingProduct.Code = productDomain.Code;
        existingProduct.Name = productDomain.Name;

        var updatedProduct = await productRepository.UpdateProduct(existingProduct);
        
        return updatedProduct.ToDomain();
    }

    public async Task DeleteProduct(Guid id)
    {
        var existingProduct = await productRepository.GetProductById(id.ToString());

        if (existingProduct == null)
        {
            throw new ProductNotFoundException($"Product with id {id} not found.");
        }
        
        await productRepository.DeleteProduct(existingProduct);
    }
}