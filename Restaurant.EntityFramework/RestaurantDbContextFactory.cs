using Microsoft.Extensions.Configuration;
using Restaurant.EntityFramework.Contexts;

namespace Restaurant.EntityFramework
{
    public class RestaurantDbContextFactory : IDbContextFactory
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public RestaurantDbContextFactory(IConfiguration cfg)
        {
            _configuration = cfg;
            _connectionString = _configuration["ConnectionString"];
        }

        public RestaurantAPIDbContext GetDbContext()
        {
            return new RestaurantAPIDbContext(_connectionString);
        }
    }
}
