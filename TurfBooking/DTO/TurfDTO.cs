namespace TurfBooking.DTO
{
    public class TurfDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Availability { get; set; }
    }
    public class NewTurfDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
    public class UpdateAvailabilityDTO {
        public bool Availability { get; set; }
    }

}
