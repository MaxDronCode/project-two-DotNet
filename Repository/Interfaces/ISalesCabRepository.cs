using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface ISalesCabRepository
{
    Task CreateSale(SaleCabEntity saleCabEntity);
}