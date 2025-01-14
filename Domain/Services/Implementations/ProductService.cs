using Store.Domain.Mappers;
using Store.Domain.Models;
using Store.Domain.Services.Interfaces;
using Store.Repository.Interfaces;

namespace Store.Domain.Services.Implementations;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public IEnumerable<ProductDomain> GetAllProducts()
    {
        var productsEntities = productRepository.GetAllProducts();

        return productsEntities.Select(entity => entity.ToDomain());
    }
}