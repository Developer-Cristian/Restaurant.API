using Microsoft.EntityFrameworkCore;
using Restaurant.EntityFramework.Contexts;
using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;

namespace Restaurant.EntityFramework.Repositories.ReadRepos
{
    public class ReadMenuRepository : IReadMenuRepository
    {
        protected ApplicationDbContext _context;

        public ReadMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> FetchAllAsync()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu> GetAsync(Guid? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            return await _context.Menus.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
