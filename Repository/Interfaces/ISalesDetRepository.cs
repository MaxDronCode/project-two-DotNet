using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface ISalesDetRepository
{
    Task<List<Top5SoldProductsEntity>> GetTop5SoldProducts();
}