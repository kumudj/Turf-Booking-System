
using Microsoft.AspNetCore.Mvc;
using TurfBooking.Models;
using TurfBooking.Services;
using TurfBooking.DTO;

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurfController : ControllerBase
    {
        private readonly ITurfService _turfService;

        public TurfController(ITurfService turfService)
        {
            _turfService = turfService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TurfDTO>> GetTurfs()
        {
            try
            {
                var turfs = _turfService.GetTurfs();
                if (turfs == null)
                {
                    return NotFound();
                }
                return Ok(turfs);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching turfs: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TurfDTO> GetTurf(int id)
        {
            try
            {
                var turf = _turfService.GetTurf(id);
                if (turf == null)
                {
                    return NotFound();
                }
                return turf;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching the turf with ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<TurfDTO> PostTurf(NewTurfDTO turf)
        {
            try
            {
                var createdTurf = _turfService.AddTurf(turf);
                return CreatedAtAction(nameof(GetTurf), new { id = createdTurf.Id }, createdTurf);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while creating a new turf: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutTurf(int id, UpdateAvailabilityDTO turf)
        {
            try
            {
                _turfService.UpdateTurf(id, turf);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while updating the turf with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTurf(int id)
        {
            try
            {
                _turfService.DeleteTurf(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while deleting the turf with ID {id}: {ex.Message}");
            }
        }
    }
}

