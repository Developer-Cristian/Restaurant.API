using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Repositories.SaveRepos
{
    public interface ISaveGenericRepositoty<T>
        where T : class, IEntity
    {
        Task<IEnumerable<ValidationResult>> SaveAsync(T entity);

        Task<IEnumerable<ValidationResult>> DelateAsync(Guid? id);
    }
}