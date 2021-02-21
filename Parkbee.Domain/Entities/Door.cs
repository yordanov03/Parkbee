using Parkbee.Domain.Common;

namespace Parkbee.Domain.Entities
{
    public class Door : AuditableEntity
    {
        #region Properties

        public int DoorId { get; set; }

        public int GarageId { get; set; }

        public Garage Garage { get; set; }

        public Status Status { get; set; }

        public string IPAddress { get; set; }

        #endregion

        #region Business Logic

        public Status SetStatus(Status status)
        {
            Status = status;
            return Status;
        }

        #endregion

    }
}
