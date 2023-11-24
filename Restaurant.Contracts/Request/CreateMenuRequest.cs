using Restaurant.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Request
{
    public class CreateMenuRequest
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        public Guid? DishId { get; set; }

        public Guid? DrinkId { get; set; }
    }
}