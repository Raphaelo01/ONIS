using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Basket.Interfaces;

public interface IBasketItemService
{
    public ValueTask<ResultObject<IBasketItemDTO>> GetBasketItemsByBasketIdAsync(int BasketId);
    public ValueTask<ResultObject<IBasketItemDTO>> InsertBasketItemAsync(int basketId, IBasketItemDTO basketItemDTO);
}
