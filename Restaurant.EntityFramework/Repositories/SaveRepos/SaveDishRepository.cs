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

        public async Task<IEnumerable<ValidationResult>> DelateAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var entity = await GetAsync(id);
            if (entity is null) throw new ArgumentNullException(nameof(id));

            _context.Dishes.Remove(entity);
            await _context.SaveChangesAsync();

            return Enumerable.Empty<ValidationResult>();
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Dish entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (entity.Id is null)
            {
                _context.Dishes.Add(entity);
            }
            else
            {
                _context.Dishes.Update(entity);
            }

            await _context.SaveChangesAsync();

            return Enumerable.Empty<ValidationResult>();
        }
    }
}
