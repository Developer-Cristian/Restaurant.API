using Restaurant.Common.Models;

namespace Restaurant.Services.SaveServices
{
    public interface ISaveGenericService<T>
        where T : class, IEntity
    {
        Task<T> SaveAsync(T model);

        Task<T> DelateAsync(Guid? id);
    }
}