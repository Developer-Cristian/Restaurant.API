using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.SaveServices
{
    public interface ISaveGenericService<T>
        where T : class, IEntity
    {
        Task<IEnumerable<ValidationResult>> SaveAsync(T model);

        Task<T> DelateAsync(Guid? id);
    }
}