using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TurfBooking.Models;


namespace TurfBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly TurfBookingContext _context;

        public BookingService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingDTO> GetBookings()
        {
            var bookings = _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Turf)
                .Select(MapToDTO)
                .ToList();

            return bookings;
        }

        public BookingDTO GetBooking(int id)
        {
            var Booking = _context.Bookings.Find(id);
            return Booking != null ? MapToDTO(Booking) : null;

        }

        public BookingDTO AddBooking(NewBookingDTO newBookingDTO)
        {
            var result=checkAvailability(newBookingDTO);
            if (!result)
            {
                var newBooking = new Booking
                {
                    SlotId = newBookingDTO.SlotId,
                    Date = newBookingDTO.Date,
                    TurfId = newBookingDTO.TurfId,
                    UserId = newBookingDTO.UserId
                };

                _context.Bookings.Add(newBooking);
                _context.SaveChanges();
                var bookingDTO = MapToDTO(newBooking);

                return bookingDTO;
            }
            return null;

            // Map the newly created Booking entity to a BookingDTO
            
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
        private BookingDTO MapToDTO(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                SlotId= booking.SlotId,
                Date=booking.Date,
                UserId = booking.UserId,
                UserName = booking.User?.Name ?? "Unknown" , // Assuming User navigation property exists
                TurfId = booking.TurfId,
                TurfName = booking.Turf?.Name ?? "Unknown" // Assuming Turf navigation property exists
            };
        }

        public bool checkAvailability(NewBookingDTO book)
        {
            var result=_context.Bookings.Any(t=>t.Date==book.Date && t.SlotId==book.SlotId && t.TurfId==book.TurfId);
            return result;
        }
        public IEnumerable<BookingDTO> GetBookingsByUser(int userId)
        {
            var bookings = _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Turf)
                .Include(b => b.User)
                .Select(MapToDTO)
                .ToList();

            return bookings;
        }



    }
}
