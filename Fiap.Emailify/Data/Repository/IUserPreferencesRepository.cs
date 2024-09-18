using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public interface IUserPreferencesRepository
    {
        Task<UserPreferences?> GetActiveThemeByEmailAsync(string email);
        Task<List<UserPreferences>> GetByEmailAsync(string email);
        Task AddAsync(UserPreferences userPreferences);
        Task UpdateAsync(UserPreferences userPreferences);
        Task<bool> SaveChangesAsync();
        Task<UserPreferences?> GetByThemeAsync(string themeName, string email);
    }

}
