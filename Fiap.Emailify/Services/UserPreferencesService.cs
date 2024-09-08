using Fiap.Emailify.Data.Repository;
using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<UserPreferences> CreateUserPreferencesAsync(UserPreferencesViewModel viewModel)
        {
            if (await _repository.GetByEmailAsync(viewModel.Email) != null)
            {
                throw new InvalidOperationException("Já existem preferências cadastradas para este e-mail.");
            }

            var userPreferences = new UserPreferences
            {
                Email = viewModel.Email,
                Theme = viewModel.Theme,
                PrimaryColor = viewModel.PrimaryColor,
                SecondaryColor = viewModel.SecondaryColor
            };

            await _repository.AddAsync(userPreferences);
            await _repository.SaveChangesAsync();

            return userPreferences;
        }

        public async Task<UserPreferences> GetUserPreferencesByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<UserPreferences> UpdateUserPreferencesAsync(int id, UserPreferencesViewModel viewModel)
        {
            var userPreferences = await _repository.GetByIdAsync(id);

            if (userPreferences == null)
            {
                throw new KeyNotFoundException("Preferências de usuário não encontradas.");
            }

            userPreferences.Theme = viewModel.Theme;
            userPreferences.PrimaryColor = viewModel.PrimaryColor;
            userPreferences.SecondaryColor = viewModel.SecondaryColor;

            await _repository.UpdateAsync(userPreferences);
            await _repository.SaveChangesAsync();

            return userPreferences;
        }

        public async Task MigrateUserPreferencesAsync(int userIdFrom, int userIdTo)
        {
            var preferencesFrom = await _repository.GetByIdAsync(userIdFrom);
            var preferencesTo = await _repository.GetByIdAsync(userIdTo);

            if (preferencesFrom == null || preferencesTo == null)
            {
                throw new KeyNotFoundException("Preferências de usuário não encontradas.");
            }

            preferencesTo.Theme = preferencesFrom.Theme;
            preferencesTo.PrimaryColor = preferencesFrom.PrimaryColor;
            preferencesTo.SecondaryColor = preferencesFrom.SecondaryColor;

            await _repository.UpdateAsync(preferencesTo);
            await _repository.SaveChangesAsync();
        }
    }

}
