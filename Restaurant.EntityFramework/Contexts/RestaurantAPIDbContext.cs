using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.EntityFramework.Contexts
{
    public class RestaurantAPIDbContext : DbContext
    {
        public RestaurantAPIDbContext(DbContextOptions<RestaurantAPIDbContext> options) : base(options)
        {
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
