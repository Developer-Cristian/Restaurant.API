using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Request
{
    public class CreateDishRequest 
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "DishTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public DishType Type { get; set; }

        [Required(ErrorMessageResourceName = "PriceTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = "PriceNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public double Price { get; set; }

        [Range(1, 5, ErrorMessageResourceName = "StarsNumberNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public int Star { get; set; }

        [Required(ErrorMessageResourceName = "MenuRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Guid? MenuId { get; set; }
    }
}