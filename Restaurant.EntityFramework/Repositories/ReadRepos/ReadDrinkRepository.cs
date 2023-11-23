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
            return await _context.Drinks.ToListAsync();
        }

        public async Task<Drink> GetAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            return await _context.Drinks.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
