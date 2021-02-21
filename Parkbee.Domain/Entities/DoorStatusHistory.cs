using System;

namespace Parkbee.Domain.Entities
{
    public class DoorStatusHistory
    {

        public int Id { get; set; }
        public int DoorId { get; set; }
        public Status PreviousStatus { get; set; }
        public Status NewStatus { get; set; }
        public DateTime TimeOfChange { get; set; }
    }
}
