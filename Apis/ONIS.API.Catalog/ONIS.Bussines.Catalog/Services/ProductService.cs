
namespace ONIS.Bussines.Catalog.Services;

public class ProductService : IProductService
{
    readonly IProductCatalogRepository _productRepository;
    public ProductService(IProductCatalogRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async ValueTask DeleteProduct(int ProductID)
    {
        await _productRepository.DeleteProductAsync(ProductID);
        await _productRepository.SaveChangesAsync();

    }

    public async ValueTask<ProductDTO?> GetProductById(int id)
    {
        return await _productRepository.GetProductAsync(id);
    }

    public async ValueTask<IEnumerable<ProductDTO>> GetProducts()
    {
        var result = await _productRepository.GetProductsAsync();
        return result;
    }

    public async ValueTask UpdateProduct(int idProduct, ProductDTO ProductDTO)
    {
        await _productRepository.UpdateProductAsync(idProduct, ProductDTO);
        await _productRepository.SaveChangesAsync();
    }


}
