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
    public class CalendarEventService : ICalendarEventService
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public CalendarEventService(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        public async Task<IEnumerable<CalendarEvent>> GetAllEventsAsync()
        {
            return await _calendarEventRepository.GetAllAsync();
        }

        public async Task<CalendarEvent> GetEventByIdAsync(int id)
        {
            return await _calendarEventRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateEventAsync(CalendarNewEventViewModel calendarEvent)
        {

            return await _calendarEventRepository.AddAsync(new CalendarEvent() {
                Title = calendarEvent.Title,
                Description = calendarEvent.Description,
                StartDate = calendarEvent.StartDate,
                EndDate = calendarEvent.EndDate,
                Location = calendarEvent.Location
            });
        }

        public async Task UpdateEventAsync(CalendarEvent calendarEvent)
        {
            await _calendarEventRepository.UpdateAsync(calendarEvent);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _calendarEventRepository.DeleteAsync(id);
        }
    }

}
