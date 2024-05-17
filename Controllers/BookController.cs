using Microsoft.AspNetCore.Mvc;
using MockBookingSystem.Models;
using MockBookingSystem.Services;

namespace MockBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IManager _manager;

        public BookController(IManager manager)
        {
            _manager = manager;
        }

        [HttpPost("Book")]
        public IActionResult Book([FromBody] BookReq request)
        {
            var bookResult = _manager.Book(request);
            return Ok(bookResult);
        }
    }
}
