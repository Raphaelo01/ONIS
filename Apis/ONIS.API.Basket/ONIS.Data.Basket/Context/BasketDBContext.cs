using Microsoft.EntityFrameworkCore;
using ONIS.Data.Basket.Entities;


namespace ONIS.Data.Basket.Context;

public class BasketDBContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<BasketCatalog> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    public BasketDBContext(DbContextOptions<BasketDBContext> options) : base(options)
    {
    }

}
