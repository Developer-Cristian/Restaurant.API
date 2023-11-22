using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Restaurant.Models
{
    public class Drink : ModelBase, IEntity
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "PriceTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = "PriceNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public double Price { get; set; }

        [Required(ErrorMessageResourceName = "MenuRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Menu Menu { get; set; }
    }
}