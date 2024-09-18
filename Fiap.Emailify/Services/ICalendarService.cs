using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public interface ICalendarEventService
    {
        Task<IEnumerable<CalendarEvent>> GetAllEventsAsync();
        Task<CalendarEvent> GetEventByIdAsync(int id);
        Task<int> CreateEventAsync(CalendarNewEventViewModel calendarEvent);
        Task UpdateEventAsync(CalendarEvent calendarEvent);
        Task DeleteEventAsync(int id);
    }

}
