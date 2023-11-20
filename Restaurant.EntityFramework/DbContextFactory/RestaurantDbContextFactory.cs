using Microsoft.Extensions.Configuration;
using Restaurant.EntityFramework;
using Restaurant.EntityFramework.Contexts;

namespace Team.Lunch.Core.EntityFramework;

public class RestaurantDbContextFactory : IDbContextFactory
{
    private IConfiguration _configuration;

    public RestaurantDbContextFactory(IConfiguration config)
    {
        _configuration = config;
    }

    public RestaurantAPIDbContext GetDbContext()
    {
        return new RestaurantAPIDbContext(_configuration);
    }
}