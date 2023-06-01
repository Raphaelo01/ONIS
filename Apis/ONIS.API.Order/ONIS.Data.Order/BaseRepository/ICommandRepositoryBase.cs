namespace ONIS.Data.Order.BaseRepository;

public interface ICommandRepositoryBase<T> : IUnitOfWork
{
    public ValueTask<T> Add(T DTOofT);
    //public ValueTask Delete(int IdOfDTO);
    //public ValueTask UpdateAsync(int Id, T DTOofT);
}
