using Store.Domain.Models;

namespace Store.Domain.Services.Interfaces;

public interface IPurchaseService
{
    Task CreatePurchase(PurchaseRequestDomain purchaseRequestDomain);
}