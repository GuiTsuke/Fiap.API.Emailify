using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public interface ICalendarRepository
    {
        Task<List<CalendarEventViewModel>> GetAllEventsAsync();
        Task CreateEventAsync(CalendarEvent calendarEvent);
    }
}
