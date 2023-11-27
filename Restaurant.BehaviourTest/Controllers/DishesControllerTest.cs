using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Restaurant.BehaviourTest.Controllers;
using Restaurant.BehaviourTest.Helpers;
using Restaurant.Contracts.Request;
using Restaurant.Contracts.Response;
using Restaurant.Models;
using System.Net;
using VGC.Operations.Api.Integration.Tests.Helpers;

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

            var list = objResult.Value as List<DishResponse>;
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task GetAsyncShouldReturn200()
        {
            //Arrange
            var request = _context.Dishes.FirstOrDefault();

            //Act
            var result = await _sut.GetAsync(request.Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult );
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var dish = objResult.Value as DishResponse;
            Assert.NotNull(dish);
            Assert.Equal(request.Id, dish.Id);
            Assert.Equal(request.Name, dish.Name);
            Assert.Equal(request.Star, dish.Star);
        }

        [Fact]
        public async Task CreateAsyncShouldReturn201()
        {
            //Arrange
            var request = AutoMapperHelper.GetConfiguration().Map<CreateDishRequest>(DataFakerHelper.DishDataFaker.Generate());
            request.MenuId = _context.Menus.FirstOrDefault().Id;

            //Act 
            var result = await _sut.CreateAsync(request);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var entity = objResult.Value as DishResponse;
            Assert.NotNull(entity);
            Assert.Equal(request.Name, entity.Name);
            Assert.Equal(entity.Star, entity.Star);
        }

        [Fact]
        public async Task UpdateAsyncShouldReturn200()
        {
            //Arrange
            var request = AutoMapperHelper.GetConfiguration().Map<UpdateDishRequest>(DataFakerHelper.DishDataFaker.Generate());

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

            var entity = objResult.Value as DishResponse;
            Assert.NotNull(entity);
            Assert.Equal(testId, entity.Id);
        }

        [Fact]
        public async Task DeleteShouldReturn200()
        {
            //Arrange
            var requestId = _context.Dishes.FirstOrDefault().Id;
            
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