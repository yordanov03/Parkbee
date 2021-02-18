using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parkbee.Domain.Entities;
using Parkbee.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkbee.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GaragesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarages()
        {
            return await _context.Garages.Select(g => new Garage
            {
                GarageId = g.GarageId,
                Name = g.Name,
                Doors = g.Doors.Select(d => new Door
                {
                    DoorId = d.DoorId,
                    GarageId = d.GarageId,
                    Status = d.Status
                }).ToList()
            }).ToListAsync();
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarage(int id)
        {
            var garage = await _context.Garages.FindAsync(id);

            if (garage == null)
            {
                return NotFound();
            }

            return garage;
        }

    }
}
