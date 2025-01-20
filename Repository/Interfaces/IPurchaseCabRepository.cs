using Store.Repository.Entities;

namespace Store.Repository.Interfaces;

public interface IPurchaseCabRepository
{
    Task CreatePurchase(PurchaseCabEntity purchaseEntity);
}