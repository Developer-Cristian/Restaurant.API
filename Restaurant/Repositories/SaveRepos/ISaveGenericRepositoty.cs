using Restaurant.Common.Models;

namespace Restaurant.Repositories.SaveRepos
{
    public interface ISaveGenericRepositoty<T>
        where T : class, IEntity
    {
        Task<T> SaveAsync(T model);

        Task<T> DelateAsync(Guid? id);
    }
}