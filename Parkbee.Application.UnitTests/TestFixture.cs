using AutoMapper;
using Parkbee.Application.Common.Interfaces;
using Parkbee.Infrastructure.Persistence;
using System;

namespace Parkbee.Application.UnitTests
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = MapperFactory.Create();
        }

        public ApplicationDbContext Context { get; }

        public IMapper Mapper { get; }
        public IDoorApiClient DoorApiClient { get; }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}
