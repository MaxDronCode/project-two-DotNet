using Microsoft.EntityFrameworkCore;
using Store.Repository.Entities;

namespace Store.Repository.dbConfig;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<ClientEntity> Clients { get; set; }
    
    public DbSet<ProductEntity> Products { get; set; }
}