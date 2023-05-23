using ONIS.Data.Catalog.BaseRepository;
using ONIS.Shared.Base.DTOs.Interfaces;

namespace ONIS.Data.Catalog.Services.Interfaces;

public interface IProductCatalogRepository : IQueryRepositoryBase<IProductDTO>, ICommandRepositoryBase<IProductDTO>
{
}
