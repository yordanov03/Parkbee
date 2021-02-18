using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parkbee.WebUI.Models
{
    public class Door
    {
        public int DoorId { get; set; }

        public int GarageId { get; set; }

        public Garage Garage { get; set; }

        public Status Status { get; set; }

    }
}
