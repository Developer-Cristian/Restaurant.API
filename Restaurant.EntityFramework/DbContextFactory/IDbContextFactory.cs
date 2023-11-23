using Restaurant.EntityFramework.Contexts;

namespace Restaurant.EntityFramework.DbContextFactory;

public interface IDbContextFactory
{
    ApplicationDbContext GetDbContext();
}
