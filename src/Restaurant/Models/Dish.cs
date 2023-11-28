using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Dish : ModelBase, IEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Description { get; set; }

        /// <summary>
        /// Dish type {appetizers = 0, first = 1, second = 2, dessert = 3, pizza = 4 }
        /// </summary>
        [Required(ErrorMessageResourceName = "DishTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public DishType Type { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required(ErrorMessageResourceName = "PriceTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = "PriceNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public double Price { get; set; }

        /// <summary>
        /// Star -> 1 to 5
        /// </summary>
        [Range(1, 5, ErrorMessageResourceName = "StarsNumberNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public int Star { get; set; }

        /// <summary>
        /// MenuId
        /// </summary>
        public Guid? MenuId { get; set; }
      
        /// <summary>
        /// Menu
        /// </summary>
        [Required(ErrorMessageResourceName = "MenuRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Menu Menu { get; set; }
    }
}