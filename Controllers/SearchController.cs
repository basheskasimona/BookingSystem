
using Microsoft.AspNetCore.Mvc;
using MockBookingSystem.Services;
using MockBookingSystem.Models;

namespace MockBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IManager _manager;

        public SearchController(IManager manager)
        {
            _manager = manager;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchReq request)
        {
            var searchResult = await _manager.Search(request);
            return Ok(searchResult);
        }
    }
}
