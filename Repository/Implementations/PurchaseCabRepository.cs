using Store.Repository.dbConfig;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Repository.Implementations;

public class PurchaseCabRepository(AppDbContext context) : IPurchaseCabRepository
{
    public async Task CreatePurchase(PurchaseCabEntity purchaseEntity)
    {
        context.PurchasesCab.Add(purchaseEntity);
        await context.SaveChangesAsync();
    }
}