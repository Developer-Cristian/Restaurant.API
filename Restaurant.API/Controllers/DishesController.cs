using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Contracts.Request;
using Restaurant.Contracts.Response;
using Restaurant.Models;
using Restaurant.Services.ReadService;
using Restaurant.Services.SaveService;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ISaveDishService _saveDishService;
        private readonly IReadDishService _readDishService;
        private readonly IReadMenuService _readMenuService;
        private readonly IMapper _mapper;

        public DishesController(ISaveDishService saveDishService, IReadDishService readDishService, IMapper mapper, IReadMenuService readMenuService)
        {
            _mapper = mapper;
            _saveDishService = saveDishService;
            _readDishService = readDishService;
            _readMenuService = readMenuService;
        }

        [HttpGet]
        [Route("FetchAllDishes")]
        [ProducesResponseType(200, Type = typeof(List<DishResponse>))]
        public async Task<IActionResult> FetchAsync()
        {
            var result = await _readDishService.FetchAllAsync();

            if (result.IsNullOrEmpty()) return NoContent();

            return Ok(_mapper.Map<List<DishResponse>>(result));
        }

        [HttpGet]
        [Route("GetDishById/{id}")]
        [ProducesResponseType(200, Type = typeof(DishResponse))]
        public async Task<IActionResult> GetAsync(Guid? id)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var result = await _readDishService.GetAsync(id);
            if (result == null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Dish", id));

            return Ok(_mapper.Map<DishResponse>(result));
        }

        [HttpPost]
        [Route("CreateDish")]
        [ProducesResponseType(201, Type = typeof(DishResponse))]
        public async Task<IActionResult> CreateAsync(CreateDishRequest request)
        {
            if (request is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var entity = _mapper.Map<Dish>(request);

            var menu = await _readMenuService.GetAsync(request.MenuId);
            if (menu is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Menu", request.MenuId));

            entity.Menu = menu;

            var errors = await _saveDishService.SaveAsync(entity);

            if (errors.Any()) return BadRequest(errors);

            return CreatedAtRoute("Dish created", _mapper.Map<DishResponse>(entity));
        }

        [HttpPut]
        [Route("UpdateDish")]
        [ProducesResponseType(200, Type = typeof(DishResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateDishRequest request)
        {
            if (request is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var existing = await _readDishService.GetAsync(request.Id);
            if (existing is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Dish", request.Id));

            var menu = await _readMenuService.GetAsync(request.MenuId);
            if (menu is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Menu", request.MenuId));

            _mapper.Map(request, existing);
            existing.Menu = menu;

            var errors = await _saveDishService.SaveAsync(existing);

            if (errors.Any()) return BadRequest(errors);

            return Ok(_mapper.Map<DishResponse>(existing));
        }

        [HttpDelete]
        [Route("DeleteDish/{id}")]
        [ProducesResponseType(200, Type = typeof(DishResponse))]
        public async Task<IActionResult> DeleteAsync(Guid? id)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var existing = await _readDishService.GetAsync(id);
            if (existing is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Dish", id));

            var errors = await _saveDishService.DelateAsync(id);

            if (errors.Any()) return BadRequest(errors);

            return Ok(_mapper.Map<DishResponse>(existing));
        }
    }
}
