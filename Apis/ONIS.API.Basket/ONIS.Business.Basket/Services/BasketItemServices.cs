using Microsoft.Extensions.Logging;
using ONIS.Business.Basket.Interfaces;
using ONIS.Data.Basket.Services.Interfaces;
using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Basket.Services;

public class BasketItemServices : IBasketItemService
{
    readonly IBasketItemRepository _basketItemRepository;
    readonly ILogger<BasketItemServices> _logger;
    public BasketItemServices(IBasketItemRepository basketItemRepository, ILogger<BasketItemServices> logger)
    {
        _basketItemRepository = basketItemRepository;
        _logger = logger;
    }
    public async ValueTask<ResultObject<IBasketItemDTO>> GetBasketItemsByBasketIdAsync(int BasketId)
    {
        var result = new ResultObject<IBasketItemDTO>();
        IEnumerable<IBasketItemDTO> orderItemDto;
        try
        {
            orderItemDto = await _basketItemRepository.GetAllAsync(BasketId);
            result.Result = orderItemDto;
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

    public async ValueTask<ResultObject<IBasketItemDTO>> InsertBasketItemAsync(int basketId, IBasketItemDTO basketItemDTO)
    {
        await _basketItemRepository.AddAsync(basketItemDTO);// throw new NotImplementedException();
        var result = await GetBasketItemsByBasketIdAsync(basketId);
        return result;
    }
}
