using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Models;

namespace Restaurant.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Model builer for entity id on table

            modelBuilder.Entity<Menu>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Dish>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Drink>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            // Model builer for connection between entity 

            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Dishes)
                .WithOne(d => d.Menu)
                .HasForeignKey(d => d.Id);

            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Drinks)
                .WithOne(d => d.Menu)
                .HasForeignKey(d => d.Id);
        }

        /// <summary>
        /// Menu db set
        /// </summary>
        public DbSet<Menu> Menus { get; set; }

        /// <summary>
        /// Dishes db set
        /// </summary>
        public DbSet<Dish> Dishes { get; set; }

        /// <summary>
        /// Drinks db set
        /// </summary>
        public DbSet<Drink> Drinks { get; set; }
    }
}
