using Store.Repository.dbConfig;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Repository.Implementations;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public IEnumerable<ProductEntity> GetAllProducts()
    {
        return context.Products.ToList();
    }
}