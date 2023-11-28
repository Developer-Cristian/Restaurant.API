using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Repositories.ReadRepos
{
    public interface IReadDishRepository : IReadGenericRepositoty<Dish>
    {
        Task<Dish> GetDishByNameAndMenuAsync(string name, Guid? menuId);
    }
}
