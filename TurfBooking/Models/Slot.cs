using System.ComponentModel.DataAnnotations;

namespace TurfBooking.Models
{
    public class Slot
    {
        [Key]
        public int SlotId {  get; set; }

        public string Time { get; set; }

    }
}
