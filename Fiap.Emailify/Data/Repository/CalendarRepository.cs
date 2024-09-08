using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly List<CalendarEvent> _events = new List<CalendarEvent>();

        public async Task<List<CalendarEventViewModel>> GetAllEventsAsync()
        {
            return await Task.FromResult(_events.Select(e => new CalendarEventViewModel
            {
                EventId = e.EventId,
                Title = e.Title,
                Date = e.Date,
                Description = e.Description
            }).ToList());
        }

        public async Task CreateEventAsync(CalendarEvent calendarEvent)
        {
            _events.Add(calendarEvent);
            await Task.CompletedTask;
        }

    }
}