namespace TurfBooking.Models
{
    public class Turf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Availability { get; set; }

        public ICollection<Booking> Bookings { get; set;}

    }
}
