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
        Task<UserPreferencesViewModel?> GetActiveUserPreferenceAsync(string email);
        Task<List<UserPreferencesViewModel>?> GetUserPreferencesAsync(string email);
        Task<bool> UpdateUserPreferencesAsync(UserPreferencesViewModel viewModel, string theme);
        Task<bool> InitializeDefaultThemesAsync(string email);
        Task<bool> SetActiveThemeAsync(string email, string themeName);
    }
}
