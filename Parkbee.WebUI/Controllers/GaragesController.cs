using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parkbee.Application.Garages.Queries.GetGarages;
using System.Threading.Tasks;

namespace Parkbee.WebUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GaragesController : ApiControllerBase
    {

        // GET: Garages
        [HttpGet]
        public async Task<ActionResult<GarageVm>> GetGarage()
        {
            return Ok(await Sender.Send(new GetGarageQuery()));
        }


    }
}
