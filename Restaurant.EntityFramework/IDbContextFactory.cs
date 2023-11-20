using Restaurant.EntityFramework.Contexts;

namespace Restaurant.EntityFramework
{
    public interface IDbContextFactory
    {
        RestaurantAPIDbContext GetDbContext();
    }
}
