using TurfBooking.Models;

namespace TurfBooking.Services
{
    public interface ISlotService
    {
        IEnumerable<Slot> GetSlots();
        Slot GetSlot(int id);
        void AddSlot(Slot newSlot);
        void UpdateSlot(int id, Slot updatedSlot);
        void DeleteSlot(int id);
    }
}
