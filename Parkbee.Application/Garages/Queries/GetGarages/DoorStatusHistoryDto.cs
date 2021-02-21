using Parkbee.Domain.Entities;
using System;

namespace Parkbee.Application.Garages.Queries.GetGarages
{
    public class DoorStatusHistoryDto
    {
        public int DoorId { get; set; }
        public Status PreviousStatus { get; set; }
        public Status NewStatus { get; set; }
        public DateTime TimeOfChange { get; set; }
    }
}
