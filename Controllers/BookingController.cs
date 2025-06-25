using Microsoft.AspNetCore.Mvc;
using ZipZop.Modals;
using ZipZop.Services.Interfaces;

namespace ZipZop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> Book(Booking booking)
        {
            var result = await _bookingService.Book(booking);
            return result == null ? BadRequest("Booking failed") : Ok(result);
        }


        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _bookingService.Cancel(id);
            return result ? Ok("Cancelled") : NotFound();
        }
    }

}
