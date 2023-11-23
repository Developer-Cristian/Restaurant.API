namespace Restaurant.Contracts.Response
{
    public class MenuResponse
    {
        public List<DishResponse> Dishes { get; set; }

        public List<DrinkResponse> Drinks { get; set; }
    }
}
