using Microsoft.EntityFrameworkCore;

namespace Restaurant.EntityFramework.Contexts
{
    public class RestaurantAPIDbContext : DbContext
    {
        private string _connectionString { get; set; }

        public RestaurantAPIDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.server(_connectionString);

            base.OnConfiguring(optionsBuilder); 
        }
    }
}
