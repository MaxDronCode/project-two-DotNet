using Microsoft.EntityFrameworkCore;
using Store.Repository.Entities;

namespace Store.Repository.dbConfig;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<SaleCabEntity> SalesCab { get; set; }

    public DbSet<SaleDetEntity> SalesDet { get; set; }

    public DbSet<PurchaseCabEntity> PurchasesCab { get; set; }

    public DbSet<PurchaseDetEntity> PurchasesDet { get; set; }

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
            entity.HasMany(saleCab => saleCab.Details)
                .WithOne()
                .HasForeignKey(saleDet => saleDet.SaleId);
        });

        modelBuilder.Entity<SaleDetEntity>(entity =>
        {
            entity.ToTable("sales_det");
            entity.HasKey(saleDet => new { saleDet.SaleId, saleDet.ProductId });
            entity.Property(e => e.SaleId)
                .IsRequired();
            entity.Property(e => e.ProductId)
                .IsRequired();
            entity.Property(e => e.Quantity)
                .IsRequired();
            entity.HasOne<ProductEntity>()
                .WithMany()
                .HasForeignKey(saleDet => saleDet.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PurchaseCabEntity>(entity =>
        {
            entity.ToTable("purchases_cab");
            entity.HasKey(purchaseCab => purchaseCab.Id);
            entity.Property(e => e.Id)
                .IsRequired();
            entity.Property(e => e.Supplier)
                .IsRequired();
            entity.HasMany(purchaseCab => purchaseCab.Details)
                .WithOne()
                .HasForeignKey(purchaseDet => purchaseDet.PurchaseId);
        });

        modelBuilder.Entity<PurchaseDetEntity>(entity =>
        {
            entity.ToTable("purchases_det");
            entity.HasKey(purchaseDet => new { purchaseDet.PurchaseId, purchaseDet.ProductId });
            entity.Property(e => e.PurchaseId)
                .IsRequired();
            entity.Property(e => e.ProductId)
                .IsRequired();
            entity.Property(e => e.Quantity)
                .IsRequired();
            entity.HasOne<ProductEntity>()
                .WithMany()
                .HasForeignKey(purchaseDet => purchaseDet.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}