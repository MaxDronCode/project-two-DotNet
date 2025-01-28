using Microsoft.EntityFrameworkCore;
using Store.Repository.dbConfig;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Repository.Implementations;

public class SalesDetRepository(AppDbContext context) : ISalesDetRepository
{
    public async Task<List<Top5SoldProductsEntity>> GetTop5SoldProducts()
    {
        var top5SolProducts = await context.SalesDet
            .Join(
                context.Products,
                salesDet => salesDet.ProductId,
                product => product.Id,
                (salesDet, product) => new
                {
                    product.Id,
                    product.Name,
                    salesDet.Quantity
                }
            )
            .GroupBy(x => new { x.Id, x.Name })
            .Select(g => new Top5SoldProductsEntity
            {
                Id = g.Key.Id,
                Name = g.Key.Name,
                Quantity = g.Sum(item => item.Quantity)
            })
            .OrderByDescending(x => x.Quantity)
            .Take(5)
            .ToListAsync();

        return top5SolProducts;
    }
}