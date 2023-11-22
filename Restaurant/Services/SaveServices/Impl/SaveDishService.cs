using Restaurant.Models;
using Restaurant.Repositories.SaveRepos;
using Restaurant.Services.SaveService;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.SaveServices.Impl
{
    public class SaveDishService : ISaveDishService
    {
        private ISaveDishRepository _repository;

        public SaveDishService(ISaveDishRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dish> DelateAsync(Guid? id)
        {
            return await _repository.DelateAsync(id);
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Dish model)
        {
            return await _repository.SaveAsync(model);
        }
    }
}
