using Parkbee.Domain.Entities;
using System.Linq;

namespace Parkbee.Infrastructure.Persistence
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
                Status = Status.Online,
                OwnerId = 1,
                CreatedBy = "Admin",
                Doors =
                {

                    new Door {  GarageId = 1, Status = Status.Online, IPAddress = "123.456.789" },
                    new Door {  GarageId = 1, Status = Status.Online, IPAddress = "023.456.789" },
                    new Door {  GarageId = 1, Status = Status.Online, IPAddress = "023.446.789" },
                    new Door {  GarageId = 1, Status = Status.Offline, IPAddress = "023.456.289"}
                }


            };

            context.Garages.Add(list);
            context.SaveChanges();
        }
    }
}
