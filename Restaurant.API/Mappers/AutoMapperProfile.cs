using AutoMapper;
using Restaurant.Contracts.Response;
using Restaurant.Models;

namespace Restaurant.API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
                CreateMap<Dish, DishResponse>();
        }
    }
}
