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
    public class DoorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Doors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Door>>> GetDoors()
        {
            return await _context.Doors.ToListAsync();
        }

        // GET: api/Doors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Door>>> GetDoors(int id)
        {
            var doors = await _context.Doors.Where(d => d.GarageId == id).ToListAsync();

            if (doors == null)
            {
                return NotFound();
            }

            return doors;
        }
    }
}
