using Microsoft.AspNetCore.Mvc;
using Restaurant.BehaviourTest.Controllers.InMemoryControllers;
using Restaurant.BehaviourTest.Helpers;
using Restaurant.Contracts.Request;
using Restaurant.Contracts.Response;
using System.Net;
using VGC.Operations.Api.Integration.Tests.Helpers;

namespace Restaurant.BehaviourTest.MenuControllers
{
    public class MenusControllerTest : InMemoryMenusController
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

            var list = objResult.Value as List<MenuResponse>;
            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task GetAsyncShouldReturn200()
        {
            //Arrange
            var request = _context.Menus.FirstOrDefault();

            //Act
            var result = await _sut.GetAsync(request.Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult );
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var Menu = objResult.Value as MenuResponse;
            Assert.NotNull(Menu);
            Assert.Equal(request.Id, Menu.Id);
            Assert.Equal(request.Name, Menu.Name);
        }

        [Fact]
        public async Task CreateAsyncShouldReturn201()
        {
            //Arrange
            var request = AutoMapperHelper.GetConfiguration().Map<CreateMenuRequest>(DataFakerHelper.MenuDataFaker.Generate());

            //Act 
            var result = await _sut.CreateAsync(request);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var entity = objResult.Value as MenuResponse;
            Assert.NotNull(entity);
            Assert.Equal(request.Name, entity.Name);
        }

        [Fact]
        public async Task UpdateAsyncShouldReturn200()
        {
            //Arrange
            var request = AutoMapperHelper.GetConfiguration().Map<UpdateMenuRequest>(DataFakerHelper.MenuDataFaker.Generate());

            // getting a randomic existing HACCP code
            var list = await _repos.FetchAllAsync();
            var testId = list.FirstOrDefault().Id;
            request.Id = testId;

            //Act 
            var result = await _sut.UpdateAsync(request);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var objResult = result as OkObjectResult;
            Assert.NotNull(objResult);
            Assert.Equal((int)HttpStatusCode.OK, objResult.StatusCode);

            var entity = objResult.Value as MenuResponse;
            Assert.NotNull(entity);
            Assert.Equal(testId, entity.Id);
        }

        [Fact]
        public async Task DeleteShouldReturn200()
        {
            //Arrange
            var requestId = _context.Menus.FirstOrDefault().Id;
            
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