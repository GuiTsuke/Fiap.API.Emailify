using Fiap.Emailify.Services;
using Fiap.Emailify.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.API.Emailify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        // GET: api/calendar/events
        [HttpGet("events")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _calendarService.GetAllEventsAsync();
            return Ok(events);
        }

        // POST: api/calendar/events/create
        [HttpPost("events/create")]
        public async Task<IActionResult> CreateEvent([FromBody] CalendarEventViewModel eventViewModel)
        {
            await _calendarService.CreateEventAsync(eventViewModel);
            return Ok(new { message = "Evento criado com sucesso!" });
        }
    }
}
