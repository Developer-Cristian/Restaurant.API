using Restaurant.Common.Models;

namespace Restaurant.Services.ReadService
{
    public interface IReadGenericService<T>
        where T : class, IEntity
    {
        Task<IEnumerable<T>> FetchAllAsync();

        Task<T> GetAsync(Guid? id);
    }
}