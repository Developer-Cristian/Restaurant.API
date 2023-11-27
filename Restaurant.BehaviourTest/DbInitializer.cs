using Restaurant.EntityFramework.Contexts;
using Restaurant.Models;

namespace Restaurant.BehaviourTest
{
    public class DbInitializer
    {
        public void Seed(ApplicationDbContext context)
        {
            var menusList = new List<Menu>();

            context.AddRange(new List<Menu>
            {
                new Menu
                {
                    Name = "Mock Restaurant",
                    CreationDate = DateTime.Now
                },
            });

            context.SaveChanges();

            var dishesList = new List<Dish>();

            context.AddRange(new List<Dish>
            {
                new Dish
                {
                    Name = "Margherita",
                    Description = "Pomodoro, mozzarella, olio e basilico",
                    CreationDate= DateTime.Now,
                    Price = 5,
                    Star = 3,
                    MenuId = context.Menus.FirstOrDefault()?.Id,
                },
            });

            context.SaveChanges();

            var drinksList = new List<Drink>();

            context.AddRange(new List<Drink>
            {
                new Drink
                {
                    Name = "Acqua",
                    Description = "Liscia",
                    CreationDate= DateTime.Now,
                    Price = 1,
                    MenuId = context.Menus.FirstOrDefault()?.Id
                },
            });

            context.SaveChanges();
        }
    }
}
