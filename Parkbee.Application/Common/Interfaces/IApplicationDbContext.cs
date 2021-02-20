using Microsoft.EntityFrameworkCore;
using Parkbee.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Parkbee.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Garage> Garages { get; set; }

        public DbSet<Door> Doors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}