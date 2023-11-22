using Restaurant.Models;
using Restaurant.Repositories.SaveRepos;
using Restaurant.Services.SaveService;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.SaveServices.Impl
{
    public class SaveMenuService : ISaveMenuService
    {
        private ISaveMenuRepository _repository;

        public SaveMenuService(ISaveMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<Menu> DelateAsync(Guid? id)
        {
            return await _repository.DelateAsync(id);
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Menu model)
        {
            return await _repository.SaveAsync(model);
        }
    }
}
