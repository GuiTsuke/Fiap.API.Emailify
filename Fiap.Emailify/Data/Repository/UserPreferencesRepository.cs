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

        public async Task<UserPreferences> AddAsync(UserPreferences userPreferences)
        {
            await _context.UserPreferences.AddAsync(userPreferences);
            return userPreferences;
        }

        public async Task<UserPreferences> GetByIdAsync(int id)
        {
            return await _context.UserPreferences.FindAsync(id);
        }

        public async Task<UserPreferences> GetByEmailAsync(string email)
        {
            return await _context.UserPreferences.FirstOrDefaultAsync(up => up.Email == email);
        }

        public async Task UpdateAsync(UserPreferences userPreferences)
        {
            await Task.FromResult(_context.UserPreferences.Update(userPreferences));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
