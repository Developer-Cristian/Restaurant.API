using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Request
{
    public class UpdateDrinkRequest : CreateDrinkRequest
    {
        [Required(ErrorMessageResourceName = "IdRequired", ErrorMessageResourceType = typeof(Common.Resources.Errors))]
        public Guid? Id { get; set; }
    }
}