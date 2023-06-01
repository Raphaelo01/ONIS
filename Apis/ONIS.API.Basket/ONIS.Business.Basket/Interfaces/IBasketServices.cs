using ONIS.Shared.Base.DTOs.Interfaces;
using ONIS.Shared.Base.Helpers;

namespace ONIS.Business.Basket.Interfaces;

public interface IBasketServices
{
    public ValueTask<ResultObject<IBasketDTO>> GetBasketsAsync();
    public ValueTask<ResultObject<IBasketDTO>> GetBasketByIdAsync(int idBasket);
    public ValueTask<ResultObject<IBasketDTO>> InsertBasketAsync(IBasketDTO basketDTO);
}
