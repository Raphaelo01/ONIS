using ONIS.Data.Basket.BaseRepository;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Basket.Services.Interfaces;

public interface IBasketItemRepository : IUnitOfWork
{
    public ValueTask AddAsync(IBasketItemDTO basketItemDTO);

    public Task<IEnumerable<IBasketItemDTO>> GetAllAsync(int basketId);

}
