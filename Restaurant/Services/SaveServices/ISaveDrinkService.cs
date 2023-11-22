using Restaurant.Models;
using Restaurant.Services.ReadService;
using Restaurant.Services.SaveServices;

namespace Restaurant.Services.SaveService
{
    public interface ISaveDrinkService : IReadDrinkService, ISaveGenericService<Drink>
    {
    }
}
