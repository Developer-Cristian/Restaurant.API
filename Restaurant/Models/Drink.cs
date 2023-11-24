using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Restaurant.Models
{
    public class Drink : ModelBase, IEntity
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
        /// Price
        /// </summary>
        [Required(ErrorMessageResourceName = "PriceTypeRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = "PriceNotValid", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public double Price { get; set; }

        /// <summary>
        /// Menu id
        /// </summary>
        public Guid? MenuId { get; set; }

        /// <summary>
        /// Menu 
        /// </summary>
        [Required(ErrorMessageResourceName = "MenuRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Menu Menu { get; set; }
    }
}