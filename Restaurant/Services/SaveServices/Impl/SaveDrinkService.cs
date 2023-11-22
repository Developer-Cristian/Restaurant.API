using Restaurant.Models;
using Restaurant.Repositories.SaveRepos;
using Restaurant.Services.SaveService;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.SaveServices.Impl
{
    public class SaveDrinkService : ISaveDrinkService
    {
        private ISaveDrinkRepository _repository;

        public SaveDrinkService(ISaveDrinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<Drink> DelateAsync(Guid? id)
        {
            return await _repository.DelateAsync(id);
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Drink model)
        {
            return await _repository.SaveAsync(model);
        }
    }
}
