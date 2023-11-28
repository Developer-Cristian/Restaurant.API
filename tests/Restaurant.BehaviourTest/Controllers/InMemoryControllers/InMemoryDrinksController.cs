using Restaurant.API.Controllers;
using Restaurant.EntityFramework.Repositories.ReadRepos;
using Restaurant.EntityFramework.Repositories.SaveRepos;
using Restaurant.Services.ReadServices.Impl;
using Restaurant.Services.SaveServices.Impl;
using VGC.Operations.Api.Integration.Tests.Helpers;

namespace Restaurant.BehaviourTest.Controllers.InMemoryControllers
{
    public class InMemoryDrinksController : InMemoryDb
    {
        protected readonly DrinksController _sut;

        protected readonly SaveDrinkRepository _repos;
        protected readonly SaveDrinkService _saveService;
        protected readonly ReadDrinkService _readService;

        protected readonly ReadMenuRepository _readMenuRepos;
        protected readonly ReadMenuService _readMenuService;

        public InMemoryDrinksController()
        {
            _repos = new SaveDrinkRepository(_context);

            _saveService = new SaveDrinkService(_repos);
            _readService = new ReadDrinkService(_repos);

            _readMenuService = new ReadMenuService(_readMenuRepos = new ReadMenuRepository(_context));

            _sut = new DrinksController(_saveService, _readService, AutoMapperHelper.GetConfiguration(), _readMenuService);

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
