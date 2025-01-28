using Store.Domain.Models;

namespace Store.Domain.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDomain> GetAllProducts();

    Task<ProductDomain> GetProductById(Guid id);

    Task<ProductDomain> CreateProduct(ProductDomain productDomain);

    Task<ProductDomain> UpdateProduct(Guid id, ProductDomain productDomain);

    Task DeleteProduct(Guid id);

    Task<ProductStockResponseDomain> GetProductStock(Guid id);
}