using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiap.Emailify.Data.Contexts;
using Fiap.Emailify.Models;
using Fiap.Emailify.Services;
using Fiap.Emailify.ViewModels;

namespace Fiap.API.Emailify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly IUserPreferencesService _userPreferencesService;

        public UserPreferencesController(IUserPreferencesService userPreferencesService)
        {
            _userPreferencesService = userPreferencesService;
        }

        // Endpoint para alternar entre dois temas predefinidos
        [HttpPost("set-active-theme")]
        public async Task<IActionResult> SetActiveTheme([FromBody] SetActiveThemeRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Theme))
            {
                return BadRequest("Email and theme are required.");
            }
            try
            {
                var result = await _userPreferencesService.SetActiveThemeAsync(request.Email, request.Theme);
                if (!result)
                {
                    return NotFound("Theme not found or invalid request.");
                }
            }
            catch(Exception ex)
            {
                return NotFound("Message: " + ex.Message);
            }                       

            return Ok("Theme has been set as active.");
        }

        // Endpoint para personalizar um tema existente
        [HttpPost("customize-theme")]
        public async Task<IActionResult> CustomizeTheme([FromQuery] string theme, [FromBody] CustomizeThemeRequest request)
        {
            if (string.IsNullOrEmpty(theme))
                return BadRequest("Determine which theme you want to customize.");

            if (string.IsNullOrEmpty(request.Email))
                return BadRequest("Email is required.");

            var result = await _userPreferencesService.UpdateUserPreferencesAsync(new UserPreferencesViewModel
            {
                Email = request.Email,
                PrimaryColor = request.PrimaryColor,
                SecondaryColor = request.SecondaryColor,
                Labels = request.Labels,
                Categories = request.Categories,
                IsDarkTheme = request.IsDarkTheme

            }, theme);

            if (!result)
            {
                return NotFound("Preferences not found.");
            }

            return Ok("Theme customized successfully.");
        }

        // Endpoint para inicializar os temas padrão
        [HttpPost("initialize-themes")]
        public async Task<IActionResult> InitializeThemes([FromBody] InitializeThemesRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("Email is required.");
            }

            var result = await _userPreferencesService.InitializeDefaultThemesAsync(request.Email);
            if (!result)
            {
                return Conflict("Themes already initialized for this user.");
            }

            return Ok("Default themes initialized.");
        }

        // Endpoint para obter as preferências do usuário
        [HttpGet("get-preferences/{email}")]
        public async Task<IActionResult> GetPreferences(string email)
        {
            var preferences = await _userPreferencesService.GetUserPreferencesAsync(email);
            if (preferences == null)
            {
                return NotFound("Preferences not found.");
            }

            return Ok(preferences);
        }

        [HttpGet("get-active-preferences/{email}")]
        public async Task<IActionResult> GetActivePreferences(string email)
        {
            try
            {
                var preferences = await _userPreferencesService.GetActiveUserPreferenceAsync(email);
                return Ok(preferences);
            }
            catch (Exception ex)
            {                
                return NotFound("Preferences not found. Message: " + ex.Message);
            }

        }
    }


}
