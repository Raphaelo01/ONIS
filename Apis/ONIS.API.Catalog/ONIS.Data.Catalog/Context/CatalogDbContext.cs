namespace ONIS.Data.Catalog.Context;

public class CatalogDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<CatalogBrand> CatalogBrands { get; set; } = null!;
    public DbSet<CatalogType> CatalogTypes { get; set; } = null!;

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
    : base(options)
    {
    }
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var catalogBrand1 = new CatalogBrand()
        {
            CatalogBrandId = 1,
            Name = "Gamesa"

        };
        var catalogBrand2 = new CatalogBrand()
        {
            CatalogBrandId = 2,
            Name = "Sabritas"
        };
        var catalogType1 = new CatalogType()
        {
            CatalogTypeId = 1,
            Name = "Type 1"
        };
        var catalogType2 = new CatalogType() { CatalogTypeId = 2, Name = "Type 2" };
        modelBuilder.Entity<CatalogBrand>().HasData(catalogBrand1, catalogBrand2,
            new CatalogBrand
            {
                CatalogBrandId = 3,
                Name = "Barcel"
            });

        modelBuilder.Entity<CatalogType>().HasData(catalogType1, catalogType2);

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "Product #1",
            AvailableStock = 1,
            CatalogBrand = catalogBrand1,
            CatalogType = catalogType1,
            CatalogBrandId = 1,
            CatalogTypeId = 1,
            Description = "First product in marketplace",
            MaxStockThreshold = 500,
            OnReorder = true,
            PictureFileName = "",
            PictureUri = "",
            Price = 500_000_000,
            RestockThreshold = 1

        }, new Product
        {
            Id = 2,
            Name = "Product #1",
            AvailableStock = 1,
            CatalogBrand = catalogBrand2,
            CatalogType = catalogType2,
            CatalogBrandId = 1,
            CatalogTypeId = 2,
            Description = "First product in marketplace",
            MaxStockThreshold = 500,
            OnReorder = true,
            PictureFileName = "",
            PictureUri = "",
            Price = 500_000_000,
            RestockThreshold = 2
        });
    }
    */

}
