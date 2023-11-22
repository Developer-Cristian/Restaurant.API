using Restaurant.EntityFramework.Contexts;
using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Repositories.SaveRepos
{
    public class SaveDishRepository : ReadDishRepository, ISaveDishRepository
    {
        public SaveDishRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<Dish> DelateAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var entity = await GetAsync(id);
            if (entity is null) throw new ArgumentNullException(nameof(id));

            _context.Dishes.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<IEnumerable<ValidationResult>> SaveAsync(Dish model)
        {
            throw new NotImplementedException();
        }
    }
}
