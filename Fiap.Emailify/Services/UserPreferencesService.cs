using Fiap.Emailify.Data.Repository;
using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public class UserPreferencesService : IUserPreferencesService
    {
        private readonly IUserPreferencesRepository _repository;

        public UserPreferencesService(IUserPreferencesRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserPreferencesViewModel?> GetActiveUserPreferenceAsync(string email)
        {
            var preferences = await _repository.GetActiveThemeByEmailAsync(email);            

            return new UserPreferencesViewModel
            {
                Email = preferences.Email,
                Theme = preferences.Theme,
                PrimaryColor = preferences.PrimaryColor,
                SecondaryColor = preferences.SecondaryColor,
                Labels = JsonSerializer.Deserialize<List<string>>(preferences.LabelsJson) ?? new List<string>(),
                Categories = JsonSerializer.Deserialize<List<string>>(preferences.CategoriesJson) ?? new List<string>(),
                IsDarkTheme = preferences.IsDarkTheme,
                IsActive = preferences.IsActive
            };
        }

        public async Task<List<UserPreferencesViewModel>?> GetUserPreferencesAsync(string email)
        {
            List<UserPreferences> preferences = await _repository.GetByEmailAsync(email);            
            if (preferences.Count == 0)
            {
                return null;
            }

            return preferences.Select(preference => new UserPreferencesViewModel
            {
                Email = preference.Email,
                Theme = preference.Theme,
                PrimaryColor = preference.PrimaryColor,
                SecondaryColor = preference.SecondaryColor,
                Labels = JsonSerializer.Deserialize<List<string>>(preference.LabelsJson) ?? new List<string>(),
                Categories = JsonSerializer.Deserialize<List<string>>(preference.CategoriesJson) ?? new List<string>(),
                IsDarkTheme = preference.IsDarkTheme,
                IsActive = preference.IsActive
            }).ToList();
        }
        public async Task<bool> UpdateUserPreferencesAsync(UserPreferencesViewModel viewModel, string theme)
        {
            var existingPreferences = await _repository.GetByThemeAsync(theme, viewModel.Email);

            if (existingPreferences == null)
            {
                return false;
            }
                        
            if (viewModel.PrimaryColor != null) existingPreferences.PrimaryColor = viewModel.PrimaryColor;
            if (viewModel.SecondaryColor != null) existingPreferences.SecondaryColor = viewModel.SecondaryColor;
            if (viewModel.Labels != null) existingPreferences.LabelsJson = JsonSerializer.Serialize(viewModel.Labels);
            if (viewModel.Categories != null) existingPreferences.CategoriesJson = JsonSerializer.Serialize(viewModel.Categories);
            if (viewModel.IsDarkTheme != null) existingPreferences.IsDarkTheme = viewModel.IsDarkTheme;

            await _repository.UpdateAsync(existingPreferences);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> InitializeDefaultThemesAsync(string email)
        {
            var existingPreferences = await _repository.GetByEmailAsync(email);
            if (existingPreferences.Count != 0)
            {
                return false;
            }

            var defaultPreferences = new List<UserPreferences>
                {
                    new UserPreferences
                    {
                        Email = email,
                        Theme = "Light",
                        PrimaryColor = "#FFFFFF", // Branco
                        SecondaryColor = "#F0F0F0", // Cinza claro
                        IsDarkTheme = false,
                        IsActive = true, // Definindo como tema padrão ativo
                        LabelsJson = JsonSerializer.Serialize(new List<string> { "Important", "Work" }),
                        CategoriesJson = JsonSerializer.Serialize(new List<string> { "Personal", "Business" })
                    },
                    new UserPreferences
                    {
                        Email = email,
                        Theme = "Dark",
                        PrimaryColor = "#000000", // Preto
                        SecondaryColor = "#2C2C2C", // Cinza escuro
                        IsDarkTheme = true,
                        IsActive = false, // Não ativo inicialmente
                        LabelsJson = JsonSerializer.Serialize(new List<string> { "Urgent", "Family" }),
                        CategoriesJson = JsonSerializer.Serialize(new List<string> { "Health", "Finance" })
                    }
                };

            // Salvar no banco de dados
            foreach (var preference in defaultPreferences)
            {
                await _repository.AddAsync(preference);
            }
            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> SetActiveThemeAsync(string email, string themeName)
        {
            var preferences = await _repository.GetActiveThemeByEmailAsync(email);
            if (preferences == null)
            {
                return false;
            }

            var newPreferences = await _repository.GetByThemeAsync(themeName, email);
            if (preferences.Equals(newPreferences))
                throw new Exception("Theme is already active.");

            if (newPreferences == null)
                throw new Exception("Theme not registered for this user.");

            preferences.IsActive = false;
            await _repository.UpdateAsync(preferences);

            newPreferences.IsActive = true;
            await _repository.UpdateAsync(newPreferences);

            return await _repository.SaveChangesAsync();
        }
    }

}
