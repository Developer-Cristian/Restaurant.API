using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Response;
using Restaurant.Services.ReadService;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveService;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ISaveDishService _saveDishService;
        private readonly IReadDishService _readDishService;
        private readonly IMapper _mapper;

        public DishesController(ISaveDishService saveDishService, IReadDishService readDishService, IMapper mapper)
        {
            _saveDishService = saveDishService;
            _readDishService = readDishService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("FetchAllDishes")]
        [ProducesResponseType(200, Type = typeof(List<DishResponse>))]
        public async Task<IActionResult> FetchAsync()
        {
            //var result = await _readDishService.FetchAllAsync();

            //if (result is null) return NoContent();

            return Ok();
        }
    }
}
