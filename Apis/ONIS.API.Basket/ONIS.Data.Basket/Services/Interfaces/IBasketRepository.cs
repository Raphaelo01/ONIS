using ONIS.Data.Basket.BaseRepository;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Basket.Services.Interfaces;

public interface IBasketRepository : IUnitOfWork
{
    public ValueTask<IBasketDTO> Add(IBasketDTO basketDTO);
    public Task<IEnumerable<IBasketDTO>> GetAllAsync();

    public Task<IBasketDTO> GetAsync(int Id);

}
