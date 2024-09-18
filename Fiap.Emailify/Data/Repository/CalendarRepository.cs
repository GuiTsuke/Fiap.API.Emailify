using Fiap.Emailify.Data.Contexts;
using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public class CalendarEventRepository : ICalendarEventRepository
    {
        private readonly DatabaseContext _context;

        public CalendarEventRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CalendarEvent>> GetAllAsync()
        {
            return await _context.CalendarEvents.ToListAsync();
        }

        public async Task<CalendarEvent> GetByIdAsync(int id)
        {
            return await _context.CalendarEvents.FindAsync(id);
        }

        public async Task<int> AddAsync(CalendarEvent calendarEvent)
        {
            await _context.CalendarEvents.AddAsync(calendarEvent);
            await _context.SaveChangesAsync();
            return calendarEvent.Id;
        }

        public async Task UpdateAsync(CalendarEvent calendarEvent)
        {
            _context.CalendarEvents.Update(calendarEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var calendarEvent = await _context.CalendarEvents.FindAsync(id);
            if (calendarEvent != null)
            {
                _context.CalendarEvents.Remove(calendarEvent);
                await _context.SaveChangesAsync();
            }
        }
    }

}