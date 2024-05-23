
using Microsoft.AspNetCore.Mvc;
using TurfBooking.Models;
using TurfBooking.Services;

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Slot>> GetSlots()
        {
            try
            {
                var slots = _slotService.GetSlots();
                if (slots == null)
                {
                    return NotFound();
                }
                return Ok(slots);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching slots: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Slot> GetSlot(int id)
        {
            try
            {
                var slot = _slotService.GetSlot(id);
                if (slot == null)
                {
                    return NotFound();
                }
                return slot;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching the slot with ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostSlot(Slot newSlot)
        {
            try
            {
                _slotService.AddSlot(newSlot);
                return CreatedAtAction(nameof(GetSlot), new { id = newSlot.SlotId }, newSlot);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while creating a new slot: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutSlot(int id, Slot updatedSlot)
        {
            try
            {
                if (id != updatedSlot.SlotId)
                {
                    return BadRequest();
                }
                _slotService.UpdateSlot(id, updatedSlot);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while updating the slot with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlot(int id)
        {
            try
            {
                _slotService.DeleteSlot(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while deleting the slot with ID {id}: {ex.Message}");
            }
        }
    }
}
