namespace ONIS.Data.Catalog.Services.Repositories;

public class ProductCatalogRepository : IProductCatalogRepository
{
    private readonly CatalogDbContext _context;
    public ProductCatalogRepository(CatalogDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var result = await _context.Products.ToListAsync();
        return result.Select(p => new ProductDTO()
        {
            Name = p.Name,
            Price = p.Price,
            AvailableStock = p.AvailableStock,
            CatalogBrandId = p.CatalogBrandId,
            CatalogTypeId = p.CatalogTypeId,
            Description = p.Description,
            MaxStockThreshold = p.MaxStockThreshold,
            OnReorder = p.OnReorder,
            PictureFileName = p.PictureFileName,
            PictureUri = p.PictureUri,
            RestockThreshold = p.RestockThreshold

        });
    }
    public async Task<ProductDTO?> GetProductAsync(int employeeId)
    {
        var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == employeeId);
        if (result == null)
            return null;
        return new ProductDTO()
        {
            Name = result.Name,
            Price = result.Price,
            AvailableStock = result.AvailableStock,
            CatalogBrandId = result.CatalogBrandId,
            CatalogTypeId = result.CatalogTypeId,
            Description = result.Description,
            MaxStockThreshold = result.MaxStockThreshold,
            OnReorder = result.OnReorder,
            PictureFileName = result.PictureFileName,
            PictureUri = result.PictureUri,
            RestockThreshold = result.RestockThreshold
        };

    }
    public async Task AddProductAsync(ProductDTO product)
    {
        // _context.Set<Product>().AddAsync(new produc)
        await _context.Products.AddAsync(new Product()
        {
            AvailableStock = product.AvailableStock,
            Name = product.Name,
            Description = product.Description,
            CatalogBrandId = product.CatalogBrandId,
            CatalogTypeId = product.CatalogTypeId,
            MaxStockThreshold = product.MaxStockThreshold,
            PictureFileName = product.PictureFileName,
            OnReorder = product.OnReorder,
            PictureUri = product.PictureUri,
            Price = product.Price,
            RestockThreshold = product.RestockThreshold
        });
    }
    public async Task DeleteProductAsync(int ProductId)
    {
        var entity = await _context.Products.Where(p => p.Id == ProductId).FirstOrDefaultAsync();
        _context.Remove(entity);
    }
    public async Task UpdateProductAsync(int ProductId, ProductDTO Product)
    {
        var productBase = await _context.Products.FirstOrDefaultAsync(p => p.Id == ProductId);
        productBase.Description = Product.Description;
        productBase.Price = Product.Price;
        productBase.AvailableStock = Product.AvailableStock;
        productBase.MaxStockThreshold = Product.MaxStockThreshold;
        productBase.Name = Product.Name;
        _context.Entry(productBase).State = EntityState.Modified;


    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

