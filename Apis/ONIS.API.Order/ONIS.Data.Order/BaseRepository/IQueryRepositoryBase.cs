namespace ONIS.Data.Order.BaseRepository;

public interface IQueryRepositoryBase<T>
{
    /// <summary>
    /// List of T object of DTO
    /// </summary>
    /// <returns>List of DTOs</returns>
    public Task<IEnumerable<T>> GetAllAsync(int OrderId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id">Id of element</param>
    /// <returns>object of DTO</returns>
    public Task<T> GetAsync(int Id);
}
