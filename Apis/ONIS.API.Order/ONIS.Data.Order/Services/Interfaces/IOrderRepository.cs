using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Order.Services.Interfaces;

public interface IOrderRepository //: ICommandRepositoryBase<IOrderDTO>, IQueryRepositoryBase<IOrderDTO>
{
    public ValueTask<IOrderDTO> Add(IOrderDTO orderDTO);
    public Task<IEnumerable<IOrderDTO>> GetAllAsync();

    public Task<IOrderDTO> GetAsync(int Id);

    public Task SaveChanges();
}
