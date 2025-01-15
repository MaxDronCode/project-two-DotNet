using Store.Domain.Models;

namespace Store.Domain.Services.Interfaces;

public interface ISalesService
{
    Task CreateSale(SaleRequestDomain saleRequestDomain);
}