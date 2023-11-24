using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Request
{
    public class CreateMenuRequest
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        /// <summary>
        /// Dish id
        /// </summary>
        public Guid? DishId { get; set; }

        /// <summary>
        /// Drink id
        /// </summary>
        public Guid? DrinkId { get; set; }
    }
}