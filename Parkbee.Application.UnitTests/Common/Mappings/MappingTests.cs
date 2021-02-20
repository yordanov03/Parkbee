using AutoMapper;
using Parkbee.Application.Garages.Queries.GetGarages;
using Parkbee.Domain.Entities;
using System;
using Xunit;

namespace Parkbee.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingFixture>
    {
        private readonly IMapper _mapper;

        public MappingTests(MappingFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _mapper
                .ConfigurationProvider
                .AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(Garage), typeof(GarageDto))]
        [InlineData(typeof(Door), typeof(DoorDto))]
        public void ShouldSupportMappingFromSourceToDestination
            (Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
