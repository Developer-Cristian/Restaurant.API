using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;
using Restaurant.Services.ReadService;

namespace Restaurant.Services.ReadServices.Impl
{
    public class ReadDrinkService : IReadDrinkService
    {
        private IReadDrinkRepository _repository;

        public ReadDrinkService(IReadDrinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Drink>> FetchAllAsync()
        {
            return await _repository.FetchAllAsync();
        }

        public async Task<Drink> GetAsync(Guid? id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
