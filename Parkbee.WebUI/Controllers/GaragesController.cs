using Microsoft.AspNetCore.Mvc;
using Parkbee.Application.Garages.Queries.GetGarages;
using System.Threading.Tasks;

namespace Parkbee.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GaragesController : ApiControllerBase
    {

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<GarageVm>> GetGarage()
        {
            return Ok(await Sender.Send(new GetGarageQuery()));
        }


    }
}
