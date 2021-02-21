using AutoMapper;
using FluentAssertions;
using Parkbee.Application.Common.Interfaces;
using Parkbee.Application.Garages.Queries.GetGarages;
using Parkbee.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Parkbee.Application.UnitTests.Garages.Queries.GetGarages
{
    [Collection(nameof(QueryCollection))]
    public class GarageQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDoorApiClient _doorApiClient;

        public GarageQueryTests(TestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _doorApiClient = fixture.DoorApiClient;
        }


        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            // Arrange
            var query = new GetGarageQuery();
            var handler = new GetGarageQueryHandler(_context, _mapper, _doorApiClient);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeOfType<GarageVm>();
            result.Garage.Should().NotBeNull();
            result.Garage.Doors.Should().HaveCount(4);
        }
    }
}
