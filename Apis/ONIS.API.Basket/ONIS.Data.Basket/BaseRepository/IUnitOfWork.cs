namespace ONIS.Data.Basket.BaseRepository;

public interface IUnitOfWork
{
    public Task SaveChanges();
}
