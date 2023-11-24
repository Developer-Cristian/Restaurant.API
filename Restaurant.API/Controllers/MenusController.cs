using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Contracts.Request;
using Restaurant.Contracts.Response;
using Restaurant.Models;
using Restaurant.Repositories.ReadRepos;
using Restaurant.Services.ReadService;
using Restaurant.Services.SaveService;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly ISaveMenuService _saveMenuService;
        private readonly IReadMenuService _readMenuService;
        private readonly IReadDishService _readDishService;
        private readonly IReadDrinkService _readDrinkService;
        private readonly IMapper _mapper;

        public MenusController(IReadMenuService readmenuService, ISaveMenuService savemenuService, IMapper mapper, IReadDrinkService readDrinkService, IReadDishService readDishService)
        {
            _mapper = mapper;
            _readMenuService = readmenuService;
            _saveMenuService = savemenuService;
            _readDrinkService = readDrinkService;
            _readDishService = readDishService;
        }

        [HttpGet]
        [Route("FetchAllMenus")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MenuResponse>))]
        public async Task<IActionResult> FetchAsync()
        {
            var result = await _readMenuService.FetchAllAsync();

            if (result.IsNullOrEmpty()) return NoContent();

            return Ok(_mapper.Map<MenuResponse>(result));
        }

        [HttpGet]
        [Route("GetMenuById/{id}")]
        [ProducesResponseType(200, Type = typeof(MenuResponse))]
        public async Task<IActionResult> GetAsync(Guid? id)
        {
            if (id is null) return BadRequest();

            var result = await _readMenuService.GetAsync(id);
            if (result is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Menu", id));

            return Ok(_mapper.Map<MenuResponse>(result));
        }

        [HttpPost]
        [Route("CreateMenu")]
        [ProducesResponseType(200, Type = typeof(MenuResponse))]
        public async Task<IActionResult> CreateAsync(CreateMenuRequest request)
        {
            if (request is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var entity = _mapper.Map<Menu>(request);

            if (request.DishId is not null)
            {
                var dish = await _readDishService.GetAsync(request.DishId);
                if (dish is null)
                    return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Dish", request.DishId));

                entity.Dishes.Add(dish);
            }

            if (request.DrinkId is not null)
            {
                var drink = await _readDrinkService.GetAsync(request.DrinkId);
                if (drink is null)
                    return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Drink", request.DrinkId));

                entity.Drinks.Add(drink);
            }

            var errors = await _saveMenuService.SaveAsync(entity);

            if (errors.Any()) return BadRequest(errors);

            return Ok(_mapper.Map<MenuResponse>(entity));
        }
    }
}
