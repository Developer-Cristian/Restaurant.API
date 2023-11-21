using Restaurant.Common.Models;

namespace Restaurant.Repositories.ReadRepos
{
    public interface IReadGenericRepositoty<T>
        where T : class, IEntity
    {
        Task<IEnumerable<T>> FetchAllAsync();

        Task<T> GetAsync(Guid? id);
    }
}