using ONIS.Data.Order.BaseRepository;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Order.Services.Interfaces;

public interface IOrderItemRepository : IUnitOfWork//IQueryRepositoryBase<IOrderItemDTO>, ICommandRepositoryBase<IOrderItemDTO>
{
    public ValueTask AddAsync(IOrderItemDTO DTOofT);

    public Task<IEnumerable<IOrderItemDTO>> GetAllAsync(int OrderId);


}
