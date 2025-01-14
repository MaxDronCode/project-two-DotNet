using Store.Domain.Models;

namespace Store.Domain.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductDomain> GetAllProducts();
}