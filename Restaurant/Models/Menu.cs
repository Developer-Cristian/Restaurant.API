using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Menu : ModelBase
    {
        public List<Dish> Dishes { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
