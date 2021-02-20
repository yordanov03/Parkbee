using Parkbee.Application.Common.Mappings;
using Parkbee.Domain.Entities;
using System.Collections.Generic;

namespace Parkbee.Application.Garages.Queries.GetGarages
{
    public class GarageDto : IMapFrom<Garage>
    {
        public int GarageId { get; set; }

        public string Name { get; set; }

        public IList<DoorDto> Doors { get; set; }
    }
}
