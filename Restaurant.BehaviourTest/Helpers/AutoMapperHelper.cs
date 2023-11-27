using AutoMapper;
using Restaurant.API.Mappers;

namespace VGC.Operations.Api.Integration.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        public static IMapper GetConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile<AutoMapperProfile>();

            });

            return config.CreateMapper();
        }
    }
}