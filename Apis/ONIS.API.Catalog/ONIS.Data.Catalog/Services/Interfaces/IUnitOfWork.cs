namespace ONIS.Data.Catalog.Services.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
