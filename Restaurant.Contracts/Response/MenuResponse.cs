using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Response
{
    public class MenuResponse
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public string Name { get; set; }

        public List<DishResponse> Dishes { get; set; }

        public List<DrinkResponse> Drinks { get; set; }
    }
}
