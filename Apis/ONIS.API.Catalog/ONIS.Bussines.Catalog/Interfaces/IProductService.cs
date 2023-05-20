namespace ONIS.Bussines.Catalog.Interfaces;
public interface IProductService
{
    public ValueTask<IEnumerable<ProductDTO>> GetProducts();
    public ValueTask<ProductDTO?> GetProductById(int id);
    public ValueTask DeleteProduct(int ProductID);
    public ValueTask UpdateProduct(int ProductId, ProductDTO ProductDTO);
}
