using Microsoft.EntityFrameworkCore;
using TurfBooking.Models;
using TurfBooking.DTO;
namespace TurfBooking.Services
{
    public class TurfService : ITurfService
    {
        private readonly TurfBookingContext _context;

        public TurfService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<TurfDTO> GetTurfs()
        {
            return _context.Turfs.Select(MapToDTO).ToList();
        }

        public TurfDTO GetTurf(int id)
        {
            var turf = _context.Turfs.Find(id);
            return turf != null ? MapToDTO(turf) : null;
        }

        public TurfDTO AddTurf(NewTurfDTO newturf)
        {
            var turf = new Turf
            {
                Availability = true,
                Location = newturf.Location,
                Name = newturf.Name

            };
            _context.Turfs.Add(turf);
            _context.SaveChanges();
            return MapToDTO(turf);
        }

        public void UpdateTurf(int id,UpdateAvailabilityDTO turfDTO)
        {
            var turf = _context.Turfs.Find(id);
            if (turf == null) return;
            turf.Availability = turfDTO.Availability;
            _context.SaveChanges();
        }

        public void DeleteTurf(int id)
        {
            var turf = _context.Turfs.Find(id);
            if (turf != null)
            {
                _context.Turfs.Remove(turf);
                _context.SaveChanges();
            }
        }

        private TurfDTO MapToDTO(Turf turf)
        {
            return new TurfDTO
            {
                Id = turf.Id,
                Name = turf.Name,
                Location = turf.Location,
                Availability = turf.Availability,

            };
        }
    }
}
