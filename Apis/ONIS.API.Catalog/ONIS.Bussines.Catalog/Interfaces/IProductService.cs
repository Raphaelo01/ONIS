using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Bussines.Catalog.Interfaces;
public interface IProductService
{
    public ValueTask<ResultObject<IProductDTO>> GetProductsAsync();
    public ValueTask<ResultObject<IProductDTO>> GetProductByIdAsync(int idProduct);
    public ValueTask InsertAsync(IProductDTO productDTO);
    public ValueTask DeleteProductAsync(int ProductID);
    public ValueTask UpdateProductAsync(int ProductId, IProductDTO ProductDTO);
}
