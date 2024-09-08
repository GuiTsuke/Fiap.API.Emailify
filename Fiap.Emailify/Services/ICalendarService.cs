using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public interface ICalendarService
    {
        Task<List<CalendarEventViewModel>> GetAllEventsAsync();
        Task CreateEventAsync(CalendarEventViewModel eventViewModel);
    }
}
