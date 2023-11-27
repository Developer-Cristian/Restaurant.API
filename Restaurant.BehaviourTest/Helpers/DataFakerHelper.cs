using Bogus;
using Restaurant.Models;

namespace Restaurant.BehaviourTest.Helpers
{
    public static class DataFakerHelper
    {  
        /// <summary>
        /// Menu mock
        /// </summary>
        public static Faker<Menu> MenuDataFaker = new Faker<Menu>()
            .RuleFor(x => x.Name, "Pizzeria italiana")
            .RuleFor(x => x.Id, Guid.NewGuid());

        /// <summary>
        /// Dish mock
        /// </summary>
        public static Faker<Dish> DishDataFaker = new Faker<Dish>()
            .RuleFor(x => x.Name, "Marinara")
            .RuleFor(x => x.Description, "Description")
            .RuleFor(x => x.CreationDate, DateTime.UtcNow)
            .RuleFor(x => x.Price, 5)
            .RuleFor(x => x.Star, 3)
            .RuleFor(x => x.Id, Guid.NewGuid());

        /// <summary>
        /// Drink mock
        /// </summary>
        public static Faker<Drink> DrinkDataFaker = new Faker<Drink>()
            .RuleFor(x => x.Name, "Birra")
            .RuleFor(x => x.Description, "Rossa")
            .RuleFor(x => x.CreationDate, DateTime.UtcNow)
            .RuleFor(x => x.Price, 5)
            .RuleFor(x => x.Id, Guid.NewGuid());
    }
}