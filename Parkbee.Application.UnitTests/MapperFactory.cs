using AutoMapper;
using Parkbee.Application.Common.Mappings;

namespace Parkbee.Application.UnitTests
{
    public static class MapperFactory
    {
        public static IMapper Create()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return configurationProvider.CreateMapper();
        }
    }
}
