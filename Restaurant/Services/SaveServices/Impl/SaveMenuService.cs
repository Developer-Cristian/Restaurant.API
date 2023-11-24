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

        public async Task<IEnumerable<ValidationResult>> DelateAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var errors = Array.Empty<ValidationResult>().ToList();

            await _repository.DelateAsync(id);
            return errors;
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Menu entity)
        {
            var errors = Array.Empty<ValidationResult>().ToList();

            if(entity.Id is null) entity.CreationDate = DateTime.Now;

            var existing = await _repository.GetAsync(entity.Id);
            if(existing != null)
            {
                errors.Add(new ValidationResult(string.Format(Common.Resources.Errors.AlreadyExisting, entity.Id), new List<string> { nameof(Menu.Id) }));
            }

            if (errors.Any())
                return errors;

            return await _repository.SaveAsync(entity);
        }
    }
}
