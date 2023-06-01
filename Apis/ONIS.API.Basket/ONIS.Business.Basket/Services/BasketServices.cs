using Microsoft.Extensions.Logging;
using ONIS.Business.Basket.Interfaces;
using ONIS.Data.Basket.Services.Interfaces;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Basket.Services;

public class BasketServices : IBasketServices
{
    readonly IBasketRepository _basketRepository;
    readonly ILogger<BasketServices> _logger;
    public BasketServices(IBasketRepository basketRepository, ILogger<BasketServices> logger)
    {
        _basketRepository = basketRepository;
        _logger = logger;
    }

    public async ValueTask<ResultObject<IBasketDTO>> GetBasketByIdAsync(int idBasket)
    {
        var result = new ResultObject<IBasketDTO>();
        IBasketDTO basketDto;
        try
        {
            basketDto = await _basketRepository.GetAsync(idBasket);
            result.Result = new List<IBasketDTO>() { basketDto };
            result.IsError = false;
            //= await _productRepository.GetAsync(idProduct);
        }
        catch (Exception ex)
        {
            result.IsError = true;
            result.Message = "Error al obtener información";// ex.Message;
            _logger.LogError(message: $"Error en {this.ToString()} / ONIS.Bussines.Basket.Services.BasketService.GetBasketByIdAsync, Mensaje Especifico exception.Message {ex.Message}, exception.InnerEx {(ex.InnerException == null ? ex.InnerException : string.Empty)}");
        }
        return result;
    }

    public async ValueTask<ResultObject<IBasketDTO>> GetBasketsAsync()
    {
        var result = new ResultObject<IBasketDTO>();
        IEnumerable<IBasketDTO> basketDto;

        try
        {
            basketDto = await _basketRepository.GetAllAsync();
            result.Result = basketDto;
            result.IsError = false;

        }
        catch (Exception ex)
        {
            _logger.LogError(message: $"Error en {this.ToString()} / ONIS.Bussines.Catalog.Services.ProductService.GetProductByIdAsync, Mensaje Especifico exception.Message {ex.Message}, exception.InnerEx {(ex.InnerException == null ? ex.InnerException : string.Empty)}");
            result.IsError = true;
            result.Message = "Error al obtener información";// ex.Message;

        }
        return result;
    }

    public async ValueTask<ResultObject<IBasketDTO>> InsertBasketAsync(IBasketDTO basketDTO)
    {
        var BasketResult = await _basketRepository.Add(basketDTO);// throw new NotImplementedException();

        var result = await GetBasketByIdAsync(BasketResult.Id);
        return result;
    }
}
