using System.ComponentModel.DataAnnotations.Schema;

namespace TurfBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int SlotId {  get; set; }

      /*  [ForeignKey("SlotId")]
        public Slot Slots { get; set; }*/
        

        public int UserId { get; set; }
        public User User { get; set; }

        public int TurfId { get; set; }
        public Turf Turf { get; set; }
    }

}
