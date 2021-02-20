using Parkbee.Domain.Common;
using System.Collections.Generic;

namespace Parkbee.Domain.Entities
{
    public class Garage : AuditableEntity
    {

        public int GarageId { get; set; }

        public string Name { get; set; }

        public IList<Door> Doors { get; set; } = new List<Door>();

        public int OwnerId { get; set; }

        public Status Status { get; set; }

    }
}
