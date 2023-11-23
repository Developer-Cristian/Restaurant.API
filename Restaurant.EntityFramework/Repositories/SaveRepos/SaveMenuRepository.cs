using Restaurant.EntityFramework.Contexts;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.Models;
using Restaurant.Repositories.SaveRepos;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.EntityFramework.Repositories.SaveRepos
{
    public class SaveMenuRepository : ReadMenuRepository, ISaveMenuRepository
    {
        public SaveMenuRepository(ApplicationDbContext _context) : base(_context)
        { }

        public async Task<IEnumerable<ValidationResult>> DelateAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var entity = await GetAsync(id);
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _context.Menus.Remove(entity);
            await _context.SaveChangesAsync();

            return Enumerable.Empty<ValidationResult>();
        }

        public async Task<IEnumerable<ValidationResult>> SaveAsync(Menu entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (entity.Id is null)
            {
                _context.Menus.Add(entity);
            }
            else
            {
                _context.Menus.Update(entity);
            }

            await _context.SaveChangesAsync();

            return Enumerable.Empty<ValidationResult>();
        }
    }
}
