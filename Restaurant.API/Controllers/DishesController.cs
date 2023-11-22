using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Response;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        [HttpGet]
        [Route("Fetch")]
        [ProducesResponseType(200, Type = typeof(List<DishResponse>)]
        public async Task<IActionResult> FetchAllDishAsync()
        {
        }
    }
}
