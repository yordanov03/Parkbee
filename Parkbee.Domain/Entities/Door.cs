namespace Parkbee.Domain.Entities
{
    public class Door
    {
        public int DoorId { get; set; }

        public int GarageId { get; set; }

        public Garage Garage { get; set; }

        public Status Status { get; set; }

    }
}
