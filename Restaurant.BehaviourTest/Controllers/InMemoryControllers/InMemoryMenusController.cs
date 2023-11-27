using Restaurant.API.Controllers;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.EntityFramework.Repositories.SaveRepos;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveServices.Impl;
using VGC.Operations.Api.Integration.Tests.Helpers;

namespace Restaurant.BehaviourTest.Controllers.InMemoryControllers
{
    public class InMemoryMenusController : InMemoryDb
    {
        protected readonly MenusController _sut;

        protected readonly SaveMenuRepository _repos;
        protected readonly SaveMenuService _saveService;
        protected readonly ReadMenuService _readService;

        protected readonly ReadDishRepository _readDishRepos;
        protected readonly ReadDishService _readDishService;

        protected readonly ReadDrinkRepository _readDrinkRepository;
        protected readonly ReadDrinkService _readDrinkService;

        public InMemoryMenusController()
        {
            _repos = new SaveMenuRepository(_context);

            _saveService = new SaveMenuService(_repos);
            _readService = new ReadMenuService(_repos);

            _readDrinkService = new ReadDrinkService(_readDrinkRepository = new ReadDrinkRepository(_context));
            _readDishService = new ReadDishService(_readDishRepos = new ReadDishRepository(_context));

            _sut = new MenusController(_readService, _saveService, AutoMapperHelper.GetConfiguration(), _readDrinkService, _readDishService);

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
