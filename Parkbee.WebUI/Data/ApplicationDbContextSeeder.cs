﻿using Parkbee.WebUI.Models;
using System.Linq;

namespace Parkbee.WebUI.Data
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Garages.Any())
            {
                return;
            }

            var list = new Garage
            {
                Name = "Garage 1",
                GarageId = 1,
                Doors =
                {
                    new Door {DoorId = 1,  GarageId = 1, Status = Status.Online },
                    new Door {DoorId = 2,  GarageId = 1, Status = Status.Online },
                    new Door { DoorId = 3, GarageId = 1, Status = Status.Online },
                    new Door {  DoorId = 4, GarageId = 1, Status = Status.Offline }
                }


            };

            context.Garages.Add(list);
            context.SaveChanges();
        }
    }
}
