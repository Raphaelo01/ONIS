namespace ONIS.Data.Order.BaseRepository;

public interface IUnitOfWork
{
    public Task SaveChanges();
}
