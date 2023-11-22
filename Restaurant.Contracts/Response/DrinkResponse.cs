namespace Restaurant.Contracts.Response
{
    public class DrinkResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public MenuResponse Menu { get; set; }
    }
}