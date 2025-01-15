﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.Repository.dbConfig;
using Store.Repository.Entities;
using Store.Repository.Interfaces;

namespace Store.Repository.Implementations;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public IEnumerable<ProductEntity> GetAllProducts()
    {
        return context.Products.ToList()!;
    }

    public async Task<ProductEntity?> GetProductById(string id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<ProductEntity?> FindProductByCode(string code)
    {
        return await context.Products.FirstOrDefaultAsync(product => product.Code == code);
    }

    public async Task<ProductEntity> CreateProduct(ProductEntity productEntity)
    {
        context.Products.Add(productEntity);
        await context.SaveChangesAsync();
        return productEntity;
    }

    public async Task<ProductEntity> UpdateProduct(ProductEntity productEntity)
    {
        context.Products.Update(productEntity);
        await context.SaveChangesAsync();
        return productEntity;
    }

    public async Task DeleteProduct(ProductEntity productEntity)
    {
        context.Products.Remove(productEntity);
        await context.SaveChangesAsync();
    }
}