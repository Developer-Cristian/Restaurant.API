using AutoMapper;
using Restaurant.Contracts.Request;
using Restaurant.Contracts.Response;
using Restaurant.Models;

namespace Restaurant.API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dish, DishResponse>(); 
            CreateMap<CreateDishRequest, Dish>();
            CreateMap<UpdateDishRequest, Dish>();

            CreateMap<Drink, DrinkResponse>();
            CreateMap<CreateDrinkRequest, Drink>();
            CreateMap<UpdateDrinkRequest, Drink>();

            CreateMap<Menu, MenuResponse>();
            CreateMap<CreateMenuRequest, Menu>();
            CreateMap<UpdateMenuRequest, Menu>();
        }
    }
}
