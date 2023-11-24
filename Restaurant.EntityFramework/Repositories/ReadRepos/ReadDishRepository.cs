using Microsoft.EntityFrameworkCore;
using Restaurant.EntityFramework.Contexts;
using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;

namespace Restaurant.EntityFramework.Repositories.ReadRepos
{
    public class ReadDishRepository : IReadDishRepository
    {
        protected ApplicationDbContext _context;

        public ReadDishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> FetchAllAsync()
        {
            return await _context.Dishes.Include(x => x.Menu).ToListAsync();
        }

        public async Task<Dish> GetAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            return await _context.Dishes.Include(x => x.Menu).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
