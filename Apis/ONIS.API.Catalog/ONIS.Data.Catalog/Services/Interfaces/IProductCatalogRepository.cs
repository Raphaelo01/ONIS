namespace ONIS.Data.Catalog.Services.Interfaces;

public interface IProductCatalogRepository : IUnitOfWork
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();

    public Task<ProductDTO> GetProductAsync(int ProductId);
    public Task AddProductAsync(ProductDTO product);
    public Task DeleteProductAsync(int ProductId);
    public Task UpdateProductAsync(int ProductId, ProductDTO product);
}
