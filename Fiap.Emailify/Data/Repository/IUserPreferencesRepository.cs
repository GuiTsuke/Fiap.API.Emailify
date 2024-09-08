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
        Task<UserPreferences> AddAsync(UserPreferences userPreferences);
        Task<UserPreferences> GetByIdAsync(int id);
        Task<UserPreferences> GetByEmailAsync(string email);
        Task SaveChangesAsync();
        Task UpdateAsync(UserPreferences userPreferences);
    }

}
