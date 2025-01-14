using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface IProductRepository
{
    IEnumerable<ProductEntity> GetAllProducts();
}