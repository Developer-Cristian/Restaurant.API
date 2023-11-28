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
            CreateMap<Dish, UpdateDishRequest>();
            CreateMap<Dish, CreateDishRequest>();
            CreateMap<CreateDishRequest, Dish>();
            CreateMap<UpdateDishRequest, Dish>();

            CreateMap<Drink, DrinkResponse>();
            CreateMap<Drink, CreateDrinkRequest>();
            CreateMap<Drink, UpdateDrinkRequest>();
            CreateMap<CreateDrinkRequest, Drink>();
            CreateMap<UpdateDrinkRequest, Drink>();

            CreateMap<Menu, MenuResponse>();
            CreateMap<Menu, CreateMenuRequest>();
            CreateMap<Menu, UpdateMenuRequest>();
            CreateMap<CreateMenuRequest, Menu>();
            CreateMap<UpdateMenuRequest, Menu>();
        }
    }
}
