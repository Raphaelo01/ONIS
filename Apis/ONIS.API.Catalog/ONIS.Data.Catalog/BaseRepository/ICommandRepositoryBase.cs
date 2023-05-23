namespace ONIS.Data.Catalog.BaseRepository;

public interface ICommandRepositoryBase<T> : IUnitOfWork
{
    public Task Add(T DTOofT);
    public Task Delete(int IdOfDTO);
    public Task UpdateAsync(int Id, T DTOofT);
}
