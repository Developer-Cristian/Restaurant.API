using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Models;

namespace Restaurant.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString;

        public ApplicationDbContext(IConfiguration configuration)
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



            modelBuilder.Entity<Menu>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Dish>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Drink>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");



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
