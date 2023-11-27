using Microsoft.EntityFrameworkCore;
using Restaurant.EntityFramework.Contexts;

namespace Restaurant.BehaviourTest.Controllers
{
    public class InMemoryDb
    {
        protected ApplicationDbContext _context;

        public InMemoryDb()
        {
            _context = CreateContext();
        }

        public ApplicationDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // use different names for different contexts! or the db will be always the same
            builder.UseInMemoryDatabase(databaseName: $"{Guid.NewGuid()}");

            var options = builder.Options;

            var dbContext = new ApplicationDbContext(options);
            // Delete existing db before creating a new one
            dbContext.Database.EnsureCreated();

            var dbInitializer = new DbInitializer();
            dbInitializer.Seed(dbContext);

            return dbContext;
        }
    }
}
