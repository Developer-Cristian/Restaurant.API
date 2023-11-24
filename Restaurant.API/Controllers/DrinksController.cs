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
    public class DrinksController : ControllerBase
    {
        private readonly ISaveDrinkService _saveDrinkService;
        private readonly IReadDrinkService _readDrinkService;
        private readonly IReadMenuService _readMenuService;
        private readonly IMapper _mapper;

        public DrinksController(ISaveDrinkService saveDrinkService, IReadDrinkService readDrinkService, IMapper mapper, IReadMenuService readMenuService)
        {
            _mapper = mapper;
            _saveDrinkService = saveDrinkService;
            _readDrinkService = readDrinkService;
            _readMenuService = readMenuService;
        }

        [HttpGet]
        [Route("FetchAllDrinks")]
        [ProducesResponseType(typeof(List<DrinkResponse>), 200)]
        public async Task<IActionResult> FetchAsync()
        {
            var result = await _readDrinkService.FetchAllAsync();

            if (result.IsNullOrEmpty()) return NoContent();

            return Ok(_mapper.Map<List<DrinkResponse>>(result));
        }

        [HttpGet]
        [Route("GetDrinkById/{id}")]
        [ProducesResponseType(200, Type = typeof(DrinkResponse))]
        public async Task<IActionResult> GetAsync(Guid? id)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _readDrinkService.GetAsync(id);
            if (result == null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Drink", id));

            return Ok(_mapper.Map<DrinkResponse>(result));
        }

        [HttpPost]
        [Route("CreateDrink")]
        [ProducesResponseType(200, Type = typeof(DrinkResponse))]
        public async Task<IActionResult> CreateAsync(CreateDrinkRequest request)
        {
            if (request is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<Drink>(request);

            var menu = await _readMenuService.GetAsync(request.MenuId);
            if (menu is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Menu", request.MenuId));

            entity.Menu = menu;

            var errors = await _saveDrinkService.SaveAsync(entity);

            if (errors.Any()) return BadRequest(errors);

            return Ok(_mapper.Map<DrinkResponse>(entity));
        }

        [HttpPut]
        [Route("UpdateDrink")]
        [ProducesResponseType(200, Type = typeof(DrinkResponse))]
        public async Task<IActionResult> UpdateAsync(UpdateDrinkRequest request)
        {
            if (request is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _readDrinkService.GetAsync(request.Id);
            if (existing is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Drink", request.Id));

            var menu = await _readMenuService.GetAsync(request.MenuId);
            if (menu is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Menu", request.MenuId));

            _mapper.Map(request, existing);
            existing.Menu = menu;

            var errors = await _saveDrinkService.SaveAsync(existing);

            if (errors.Any()) return BadRequest(errors);

            return Ok(_mapper.Map<DrinkResponse>(existing));
        }

        [HttpDelete]
        [Route("DeleteDrink/{id}")]
        [ProducesResponseType(200, Type = typeof(DrinkResponse))]
        public async Task<IActionResult> DeleteAsync(Guid? id)
        {
            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _readDrinkService.GetAsync(id);
            if (existing is null)
                return NotFound(string.Format(Common.Resources.Errors.EntityWithIdNotFound, "Drink", id));

            var errors = await _saveDrinkService.DelateAsync(id);

            if (errors.Any()) return BadRequest(errors);

            return Ok(_mapper.Map<DrinkResponse>(existing));
        }
    }
}
