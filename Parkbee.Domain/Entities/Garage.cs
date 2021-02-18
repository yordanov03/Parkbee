using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parkbee.Domain.Entities
{
    public class Garage
    {

        public int GarageId { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public List<Door> Doors { get; set; } = new List<Door>();

        //public int OwnerId { get; set; }

        public Status Status { get; set; }

    }
}
