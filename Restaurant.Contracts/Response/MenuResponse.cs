using System.ComponentModel.DataAnnotations;

namespace Restaurant.Contracts.Response
{
    public class MenuResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<DishResponse> Dishes { get; set; }

        public List<DrinkResponse> Drinks { get; set; }
    }
}
