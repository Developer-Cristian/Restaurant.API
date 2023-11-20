using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

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
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");
        }

        /// <summary>
        /// Dishes db set
        /// </summary>
        public DbSet<Dish> Dishes { get; set; }
    }
}
