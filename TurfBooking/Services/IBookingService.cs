using System.Collections.Generic;
using TurfBooking.Models;

namespace TurfBooking.Services
{
    public interface IBookingService
    {
        IEnumerable<BookingDTO> GetBookings();
        BookingDTO GetBooking(int id);
        BookingDTO AddBooking(NewBookingDTO booking);

        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
        IEnumerable<BookingDTO> GetBookingsByUser(int userId);
    }
}
