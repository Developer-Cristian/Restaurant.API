using Restaurant.Common.Models;

namespace Restaurant.Contracts.Response
{
    public class DishResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DishType Type { get; set; }

        public double Price { get; set; }

        public int Star { get; set; }

        public MenuResponse Menu { get; set; }
    }
}