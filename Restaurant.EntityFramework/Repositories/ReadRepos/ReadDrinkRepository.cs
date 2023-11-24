using Microsoft.EntityFrameworkCore;
using Restaurant.EntityFramework.Contexts;
using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;

namespace Restaurant.EntityFramework.Repositories.ReadRepos
{
    public class ReadDrinkRepository : IReadDrinkRepository
    {
        protected ApplicationDbContext _context;

        public ReadDrinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Drink>> FetchAllAsync()
        {
            return await _context.Drinks.Include(x => x.Menu).ToListAsync();
        }

        public async Task<Drink> GetAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            return await _context.Drinks.Include(x => x.Menu).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Drink> GetDrinkByNameAndMenuAsync(string name, Guid? menuId)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (menuId is null) throw new ArgumentNullException(nameof(menuId));

            var existing = await _context.Drinks.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.MenuId.Equals(menuId));

            if (existing != null) return existing;

            return null;
        }
    }
}
