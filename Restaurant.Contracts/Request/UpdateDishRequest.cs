using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Request
{
    public class UpdateDishRequest : CreateDishRequest
    {
        [Required(ErrorMessageResourceName = "IdRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Guid? Id { get; set; }
    }
}