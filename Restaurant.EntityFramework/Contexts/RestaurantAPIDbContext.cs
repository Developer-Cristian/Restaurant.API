using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Models;

namespace Restaurant.EntityFramework.Contexts
{
    public class RestaurantAPIDbContext : DbContext
    {
        private string _connectionString;

        public RestaurantAPIDbContext(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Menu>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");
        }

        /// <summary>
        /// Dishes db set
        /// </summary>
        public DbSet<Dish> Dishes { get; set; }

        /// <summary>
        /// Menu db set
        /// </summary>
        public DbSet<Menu> Menus { get; set; }
    }
}
