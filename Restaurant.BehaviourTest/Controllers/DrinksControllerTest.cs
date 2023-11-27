using Microsoft.AspNetCore.Mvc;
using Restaurant.BehaviourTest.Controllers.InMemoryControllers;
using Restaurant.BehaviourTest.Helpers;
using Restaurant.Contracts.Request;
using Restaurant.Contracts.Response;
using System.Net;
using VGC.Operations.Api.Integration.Tests.Helpers;

namespace Restaurant.BehaviourTest.DrinkControllers
{
    public class DrinksControllerTest : InMemoryDrinksController
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

            var list = objResult.Value as List<DrinkResponse>;
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task GetAsyncShouldReturn200()
        {
            //Arrange
            var request = _context.Drinks.FirstOrDefault();

            //Act
            var result = await _sut.GetAsync(request.Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult );
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var Drink = objResult.Value as DrinkResponse;
            Assert.NotNull(Drink);
            Assert.Equal(request.Id, Drink.Id);
            Assert.Equal(request.Name, Drink.Name);
            Assert.Equal(request.Price, Drink.Price);
        }

        [Fact]
        public async Task CreateAsyncShouldReturn201()
        {
            //Arrange
            var request = AutoMapperHelper.GetConfiguration().Map<CreateDrinkRequest>(DataFakerHelper.DrinkDataFaker.Generate());
            request.MenuId = _context.Menus.FirstOrDefault().Id;

            //Act 
            var result = await _sut.CreateAsync(request);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var entity = objResult.Value as DrinkResponse;
            Assert.NotNull(entity);
            Assert.Equal(request.Name, entity.Name);
            Assert.Equal(entity.Price, entity.Price);
        }

        [Fact]
        public async Task UpdateAsyncShouldReturn200()
        {
            //Arrange
            var request = AutoMapperHelper.GetConfiguration().Map<UpdateDrinkRequest>(DataFakerHelper.DrinkDataFaker.Generate());

            // getting a randomic existing HACCP code
            var list = await _repos.FetchAllAsync();
            var testId = list.FirstOrDefault().Id;
            request.Id = testId;
            request.MenuId = _context.Menus.FirstOrDefault().Id;

            //Act 
            var result = await _sut.UpdateAsync(request);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var entity = objResult.Value as DrinkResponse;
            Assert.NotNull(entity);
            Assert.Equal(testId, entity.Id);
        }

        [Fact]
        public async Task DeleteShouldReturn200()
        {
            //Arrange
            var requestId = _context.Drinks.FirstOrDefault().Id;
            
            //Act
            var result = await _sut.DeleteAsync(requestId);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);
        }
    }
}