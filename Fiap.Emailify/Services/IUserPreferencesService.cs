using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public interface IUserPreferencesService
    {
        Task<UserPreferences> CreateUserPreferencesAsync(UserPreferencesViewModel viewModel);
        Task<UserPreferences> GetUserPreferencesByIdAsync(int id);
        Task<UserPreferences> UpdateUserPreferencesAsync(int id, UserPreferencesViewModel viewModel);
        Task MigrateUserPreferencesAsync(int userIdFrom, int userIdTo);
    }
}
