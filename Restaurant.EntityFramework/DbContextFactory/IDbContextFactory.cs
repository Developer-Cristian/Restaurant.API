using Restaurant.EntityFramework.Contexts;

namespace Restaurant.EntityFramework;

public interface IDbContextFactory
{
    ApplicationDbContext GetDbContext();
}
