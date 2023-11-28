using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;
using Restaurant.Services.ReadService;

namespace Restaurant.Services.ReadServices.Impl
{
    public class ReadMenuService : IReadMenuService
    {
        private IReadMenuRepository _repository;

        public ReadMenuService(IReadMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Menu>> FetchAllAsync()
        {
            return await _repository.FetchAllAsync();
        }

        public async Task<Menu> GetAsync(Guid? id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
