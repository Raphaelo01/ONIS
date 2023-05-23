using Microsoft.Extensions.Logging;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Bussines.Catalog.Services;

public class ProductService : IProductService
{
    readonly IProductCatalogRepository _productRepository;
    readonly ILogger<ProductService> _logger;
    public ProductService(IProductCatalogRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public async ValueTask<ResultObject<IProductDTO>> GetProductByIdAsync(int idProduct)
    {
        var result = new ResultObject<IProductDTO>();
        IProductDTO productDto;

        try
        {
            productDto = await _productRepository.GetAsync(idProduct);
            result.Result = new List<IProductDTO>() { productDto };
            result.IsError = false;
            //= await _productRepository.GetAsync(idProduct);
        }
        catch (Exception ex)
        {
            result.IsError = true;
            result.Message = "Error al obtener información";// ex.Message;
            _logger.LogError(message: $"Error en {this.ToString()} / ONIS.Bussines.Catalog.Services.ProductService.GetProductByIdAsync, Mensaje Especifico exception.Message {ex.Message}, exception.InnerEx {(ex.InnerException == null ? ex.InnerException : string.Empty)}");
        }
        return result;
    }
    public async ValueTask<ResultObject<IProductDTO>> GetProductsAsync()
    {
        var result = new ResultObject<IProductDTO>();
        IEnumerable<IProductDTO> productsDto;

        try
        {
            productsDto = await _productRepository.GetAllAsync();
            result.Result = productsDto;
            result.IsError = false;

        }
        catch (Exception ex)
        {
            result.IsError = true;
            result.Message = "Error al obtener información";// ex.Message;
            _logger.LogError(message: $"Error en {this.ToString()} / ONIS.Bussines.Catalog.Services.ProductService.GetProductByIdAsync, Mensaje Especifico exception.Message {ex.Message}, exception.InnerEx {(ex.InnerException == null ? ex.InnerException : string.Empty)}");
        }


        return result;
    }
    public async ValueTask InsertAsync(IProductDTO productDTO)
    {
        await _productRepository.Add(productDTO);// throw new NotImplementedException();
        await _productRepository.SaveChangesAsync();
    }
    public async ValueTask UpdateProductAsync(int ProductId, IProductDTO ProductDTO)
    {
        await _productRepository.UpdateAsync(ProductId, ProductDTO);
        await _productRepository.SaveChangesAsync();
    }
    public async ValueTask DeleteProductAsync(int ProductID)
    {
        await _productRepository.Delete(ProductID);
        await _productRepository.SaveChangesAsync();
    }

}
