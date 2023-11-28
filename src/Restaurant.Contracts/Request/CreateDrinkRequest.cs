using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Request
{
    public class CreateDrinkRequest 
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
        [Required(ErrorMessageResourceName = "MenuRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Guid? MenuId { get; set; }
    }
}