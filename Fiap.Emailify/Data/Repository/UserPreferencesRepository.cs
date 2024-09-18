using Fiap.Emailify.Data.Contexts;
using Fiap.Emailify.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public class UserPreferencesRepository : IUserPreferencesRepository
    {
        private readonly DatabaseContext _context;

        public UserPreferencesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<UserPreferences?> GetActiveThemeByEmailAsync(string email)
        {
            return await _context.UserPreferences.FirstAsync(up => up.Email == email && up.IsActive);
        }

        public async Task<List<UserPreferences>> GetByEmailAsync(string email)
        {
            return await _context.UserPreferences.AsQueryable().Where(up => up.Email == email).ToListAsync();
        }               

        public async Task AddAsync(UserPreferences userPreferences)
        {
            await _context.UserPreferences.AddAsync(userPreferences);
        }
        public async Task UpdateAsync(UserPreferences userPreferences)
        {
            await Task.FromResult(_context.UserPreferences.Update(userPreferences));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UserPreferences?> GetByThemeAsync(string themeName, string email)
        {
            return await _context.UserPreferences
                                 .FirstOrDefaultAsync(up => up.Theme == themeName && up.Email == email);
        }
    }

}
