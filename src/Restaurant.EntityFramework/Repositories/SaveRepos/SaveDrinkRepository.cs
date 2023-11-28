using Restaurant.EntityFramework.Contexts;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.Models;
using Restaurant.Repositories.SaveRepos;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.EntityFramework.Repositories.SaveRepos
{
    public class SaveDrinkRepository : ReadDrinkRepository, ISaveDrinkRepository
    {
        public SaveDrinkRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<IEnumerable<ValidationResult>> DelateAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var entity = await GetAsync(id);
            if (entity is null) throw new ArgumentNullException(nameof(id));

            _context.Drinks.Remove(entity);
            await _context.SaveChangesAsync();

            return Enumerable.Empty<ValidationResult>();
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Drink entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (entity.Id is null)
            {
                _context.Drinks.Add(entity);
            }
            else
            {
                _context.Drinks.Update(entity);
            }

            await _context.SaveChangesAsync();

            return Enumerable.Empty<ValidationResult>();
        }
    }
}
