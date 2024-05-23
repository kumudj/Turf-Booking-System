using System.Collections.Generic;
using TurfBooking.Models;
using TurfBooking.DTO;

namespace TurfBooking.Services
{
    public interface ITurfService
    {
        IEnumerable<TurfDTO> GetTurfs();
        TurfDTO GetTurf(int id);
        TurfDTO AddTurf(NewTurfDTO turf);
        void UpdateTurf(int id ,UpdateAvailabilityDTO dto);
        void DeleteTurf(int id);
    }
}