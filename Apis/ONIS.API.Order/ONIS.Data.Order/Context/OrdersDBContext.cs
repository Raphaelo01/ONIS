namespace ONIS.Data.Order.Context;
using Microsoft.EntityFrameworkCore;


using ONIS.Data.Order.Entities;
public class OrdersDbContext : DbContext
{
    public DbSet<Address> Address { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    {
    }
}
