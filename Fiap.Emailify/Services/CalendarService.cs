using Fiap.Emailify.Data.Repository;
using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _repository;

        public CalendarService(ICalendarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CalendarEventViewModel>> GetAllEventsAsync()
        {
            return await _repository.GetAllEventsAsync();
        }

        public async Task CreateEventAsync(CalendarEventViewModel eventViewModel)
        {
            var calendarEvent = new CalendarEvent
            {
                EventId = Guid.NewGuid().ToString(),
                Title = eventViewModel.Title,
                Date = eventViewModel.Date,
                Description = eventViewModel.Description
            };

            await _repository.CreateEventAsync(calendarEvent);
        }
    }
}
