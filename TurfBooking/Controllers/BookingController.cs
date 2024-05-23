
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using TurfBooking.Models;
using TurfBooking.Services;

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            try
            {
                var bookings = _bookingService.GetBookings();
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching bookings: {ex.Message}");
            }
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public ActionResult<BookingDTO> GetBooking(int id)
        {
            try
            {
                var booking = _bookingService.GetBooking(id);
                if (booking == null)
                {
                    return NotFound();
                }
                return booking;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching the booking with ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<BookingDTO> PostBooking(NewBookingDTO booking)
        {
            try
            {
                var createdbooking = _bookingService.AddBooking(booking);
                if (createdbooking != null)
                {
                    return CreatedAtAction("GetBooking", new { id = createdbooking.Id }, createdbooking);
                }
                return BadRequest("Already booked");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while creating a new booking: {ex.Message}");
            }
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public IActionResult PutBooking(int id, Booking booking)
        {
            try
            {
                if (id != booking.Id)
                {
                    return BadRequest();
                }
                _bookingService.UpdateBooking(booking);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while updating the booking with ID {id}: {ex.Message}");
            }
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                var booking = _bookingService.GetBooking(id);
                if (booking == null)
                {
                    return NotFound();
                }
                _bookingService.DeleteBooking(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while deleting the booking with ID {id}: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<BookingDTO>> GetBookingsByUser(int userId)
        {
            try
            {
                var bookings = _bookingService.GetBookingsByUser(userId);
                if (bookings == null || !bookings.Any())
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching bookings for user with ID {userId}: {ex.Message}");
            }
        }
    }
}
