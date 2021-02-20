using AutoMapper;
using Parkbee.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}
