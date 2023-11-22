using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Response;
using Restaurant.Services.SaveService;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ISaveDishService _saveDishService;
        private readonly IMapper _mapper;

        public DishesController(ISaveDishService saveDishService, IMapper mapper)
        {
            _saveDishService = saveDishService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("FetchAllDishes")]
        [ProducesResponseType(200, Type = typeof(List<DishResponse>))]
        public async Task<IActionResult> FetchAsync()
        {
            var result = _saveDishService.

            return Ok();
        }
    }
}
