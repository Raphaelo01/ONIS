using ONIS.Shared.Base.DTOs;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.DTOs.NullDTOs;

namespace ONIS.Data.Catalog.Services.Repositories;

public class ProductCatalogRepository : IProductCatalogRepository
{
    private readonly CatalogDbContext _context;
    public ProductCatalogRepository(CatalogDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<IProductDTO>> GetAllAsync()
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
    public async Task<IProductDTO> GetAsync(int Id)
    {
        var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
        if (result == null)
            return new NullProductDTO();
        return new ProductDTO()
        {
            Name = result.Name ?? "",
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
    public async Task Delete(int Id)
    {
        var entity = await _context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();
        if (entity != null)
        {
            _context.Products.Remove(entity);
        }
    }

    public async Task UpdateAsync(int Id, IProductDTO product)
    {
        var productBase = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
        if (productBase != null)
        {
            productBase.Description = product.Description;
            productBase.Price = product.Price;
            productBase.AvailableStock = product.AvailableStock;
            productBase.MaxStockThreshold = product.MaxStockThreshold;
            productBase.Name = product.Name;
            _context.Entry(productBase).State = EntityState.Modified;
        }
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Add(IProductDTO product)
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

}

