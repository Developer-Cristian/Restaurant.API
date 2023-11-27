using Restaurant.API.Controllers;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.EntityFramework.Repositories.SaveRepos;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveServices.Impl;
using VGC.Operations.Api.Integration.Tests.Helpers;

namespace Restaurant.BehaviourTest.Controllers
{
    public class InMemoryDishesController : InMemoryDb
    {
        protected readonly DishesController _sut;

        protected readonly SaveDishRepository _repos;
        protected readonly SaveDishService _saveService;
        protected readonly ReadDishService _readService;

        protected readonly ReadMenuRepository _readMenuRepos;
        protected readonly ReadMenuService _readMenuService;

        public InMemoryDishesController()
        {
            _repos = new SaveDishRepository(_context);

            _saveService = new SaveDishService(_repos);
            _readService = new ReadDishService(_repos);

            _readMenuService = new ReadMenuService(_readMenuRepos = new ReadMenuRepository(_context));

            _sut = new DishesController(_saveService, _readService, AutoMapperHelper.GetConfiguration(), _readMenuService);

            //var newIdentity = new GenericIdentity("user-name", "Bearer");
            //newIdentity.AddClaim(new Claim("tid", DataFakerHelper.TenantId));

            //Sut.ControllerContext = new ControllerContext
            //{
            //    HttpContext = new DefaultHttpContext
            //    {
            //        User = new ClaimsPrincipal(newIdentity)
            //    }
            //};
        }
    }
}
