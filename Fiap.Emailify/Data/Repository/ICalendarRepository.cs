using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public interface ICalendarEventRepository
    {
        Task<IEnumerable<CalendarEvent>> GetAllAsync();
        Task<CalendarEvent> GetByIdAsync(int id);
        Task<int> AddAsync(CalendarEvent calendarEvent);
        Task UpdateAsync(CalendarEvent calendarEvent);
        Task DeleteAsync(int id);
    }

}
