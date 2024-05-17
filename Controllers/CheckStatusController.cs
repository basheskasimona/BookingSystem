using Microsoft.AspNetCore.Mvc;
using MockBookingSystem.Services;
using MockBookingSystem.Models;

namespace MockBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckStatusController : ControllerBase
    {

        private readonly IManager _manager;

        public CheckStatusController(IManager manager)
        {
            _manager = manager;
        }

        [HttpGet("CheckStatus")]
        public IActionResult CheckStatus([FromQuery] CheckStatusReq request)
        {
            var statusResult = _manager.CheckStatus(request);
            return Ok(statusResult);
        }
    }
}

