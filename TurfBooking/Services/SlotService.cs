using TurfBooking.Models;
using TurfBooking.Services;

namespace TurfBooking.Services
{
    public class SlotService : ISlotService
    {
        private readonly TurfBookingContext _context;

        public SlotService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Slot> GetSlots()
        {
            return _context.Slots.ToList();
        }

        public Slot GetSlot(int id)
        {
            return _context.Slots.Find(id);
        }

        public void AddSlot(Slot newSlot)
        {
            _context.Slots.Add(newSlot);
            _context.SaveChanges();
        }

        public void UpdateSlot(int id, Slot updatedSlot)
        {
            var slot = _context.Slots.Find(id);
            if (slot != null)
            {
                slot.Time = updatedSlot.Time;
                _context.Slots.Update(slot);
                _context.SaveChanges();
            }
        }

        public void DeleteSlot(int id)
        {
            var slot = _context.Slots.Find(id);
            if (slot != null)
            {
                _context.Slots.Remove(slot);
                _context.SaveChanges();
            }
        }
    }
}
