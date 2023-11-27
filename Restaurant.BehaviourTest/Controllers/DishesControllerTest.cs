using Microsoft.AspNetCore.Mvc;
using Restaurant.BehaviourTest.Controllers;
using Restaurant.Models;
using System.Net;

namespace Restaurant.BehaviourTest.DishControllers
{
    public class DishesControllerTest : InMemoryDishesController
    {
        [Fact]
        public async Task FetchAsyncShouldReturn200()
        {
            //Act
            var result = await _sut.FetchAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var list = objResult.Value as List<Dish>;
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }
    }
}