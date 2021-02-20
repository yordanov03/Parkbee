using Parkbee.Domain.Common;

namespace Parkbee.Domain.Entities
{
    public class Door : AuditableEntity
    {
        public int DoorId { get; set; }

        public int GarageId { get; set; }

        public Garage Garage { get; set; }

        public Status Status { get; set; }

    }
}
