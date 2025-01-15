using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Repository.Entities;

namespace Store.Repository.dbConfig;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ClientEntity> Clients { get; set; }
    
    public DbSet<ProductEntity> Products { get; set; }
    
    public DbSet<SaleCabEntity> SalesCab { get; set; }
    
    public DbSet<SaleDetEntity> SalesDet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClientEntity>(entity =>
        {
            entity.ToTable("clients");
            entity.HasKey(client => client.Id);
            entity.Property(e => e.Id)
                .IsRequired();
            entity.Property(e => e.Name)
                .IsRequired();
            entity.Property(e => e.Nif)
                .IsRequired();
        });

        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.ToTable("products");
            entity.HasKey(product => product.Id);
            entity.Property(e => e.Id)
                .IsRequired();
            entity.Property(e => e.Code)
                .IsRequired();
            entity.Property(e => e.Name)
                .IsRequired();
            entity.Property(e => e.Stock)
                .IsRequired();
        });
        
        modelBuilder.Entity<SaleCabEntity>(entity =>
        {
            entity.ToTable("sales_cab");
            entity.HasKey(saleCab => saleCab.Id);
            entity.Property(e => e.Id)
                .IsRequired();
            entity.Property(e => e.ClientId)
                .IsRequired();
            entity.HasOne<ClientEntity>()
                .WithMany()
                .HasForeignKey(saleCab => saleCab.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SaleDetEntity>(entity =>
        {
            entity.ToTable("sales_det");
            entity.HasKey(saleDet => new {saleDet.SaleId, saleDet.ProductId});
            entity.Property(e => e.SaleId)
                .IsRequired();
            entity.Property(e => e.ProductId)
                .IsRequired();
            entity.Property(e => e.Quantity)
                .IsRequired();
            entity.HasOne<SaleCabEntity>()
                .WithMany()
                .HasForeignKey(saleDet => saleDet.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<ProductEntity>()
                .WithMany()
                .HasForeignKey(saleDet => saleDet.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        });

    }
    
}