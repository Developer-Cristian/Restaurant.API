using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Menu : ModelBase, IEntity
    {
        public List<Dish> Dishes { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
