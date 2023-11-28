using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;
using Restaurant.Services.ReadService;

namespace Restaurant.Services.ReadServices.Impl
{
    public class ReadDishService : IReadDishService
    {
        private IReadDishRepository _repository;

        public ReadDishService(IReadDishRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Dish>> FetchAllAsync()
        {
            return await _repository.FetchAllAsync();
        }

        public async Task<Dish> GetAsync(Guid? id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
