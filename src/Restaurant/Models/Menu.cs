using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Menu : ModelBase, IEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }
       
        /// <summary>
        /// List of dishes
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }

        /// <summary>
        /// List of drinks
        /// </summary>
        public ICollection<Drink> Drinks { get; set; }
    }
}
