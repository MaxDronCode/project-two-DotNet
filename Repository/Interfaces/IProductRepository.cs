using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface IProductRepository
{
    IEnumerable<ProductEntity> GetAllProducts();
    
    Task<ProductEntity?> GetProductById(string id);
    
    Task<ProductEntity?> FindProductByCode(string code);
    
    Task<ProductEntity> CreateProduct(ProductEntity productEntity);
}