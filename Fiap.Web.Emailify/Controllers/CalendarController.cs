using Fiap.Emailify.Models;
using Fiap.Emailify.Services;
using Fiap.Emailify.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.API.Emailify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarEventController : ControllerBase
    {
        private readonly ICalendarEventService _calendarEventService;

        public CalendarEventController(ICalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _calendarEventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var calendarEvent = await _calendarEventService.GetEventByIdAsync(id);
            if (calendarEvent == null)
            {
                return NotFound();
            }
            return Ok(calendarEvent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CalendarNewEventViewModel calendarEvent)
        {
            int id = await _calendarEventService.CreateEventAsync(calendarEvent);
            return CreatedAtAction(nameof(GetEventById), new {Id = id}, calendarEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] CalendarEvent calendarEvent)
        {
            var existingEvent = await _calendarEventService.GetEventByIdAsync(id);
            if (existingEvent == null)
            {
                return NotFound();
            }
            existingEvent.Title = calendarEvent.Title;
            existingEvent.StartDate = calendarEvent.StartDate;
            existingEvent.EndDate = calendarEvent.EndDate;
            existingEvent.Location = calendarEvent.Location;
            existingEvent.Description = calendarEvent.Description;

            await _calendarEventService.UpdateEventAsync(existingEvent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var existingEvent = await _calendarEventService.GetEventByIdAsync(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            await _calendarEventService.DeleteEventAsync(id);
            return NoContent();
        }
    }

}
