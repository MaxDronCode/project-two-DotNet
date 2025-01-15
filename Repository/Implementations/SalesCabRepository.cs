using Store.Repository.dbConfig;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Repository.Implementations;

public class SalesCabRepository(AppDbContext context) : ISalesCabRepository
{
    public async Task CreateSale(SaleCabEntity saleCabEntity)
    {
        context.SalesCab.Add(saleCabEntity);
        await context.SaveChangesAsync();
    }
}