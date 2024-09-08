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
    [Route("api/[controller]")]
    [ApiController]
    public class UserPreferencesController : ControllerBase
    {
        private readonly IUserPreferencesService _userPreferencesService;

        public UserPreferencesController(IUserPreferencesService userPreferencesService)
        {
            _userPreferencesService = userPreferencesService;
        }

        // POST: api/UserPreferences
        [HttpPost]
        public async Task<IActionResult> CreateUserPreferences([FromBody] UserPreferencesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userPreferencesService.CreateUserPreferencesAsync(viewModel);
                return Ok(new { message = "Preferências cadastradas com sucesso!", result });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // GET: api/UserPreferences/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPreferencesById(int id)
        {
            var preferences = await _userPreferencesService.GetUserPreferencesByIdAsync(id);
            if (preferences == null)
            {
                return NotFound(new { message = "Preferências de usuário não encontradas." });
            }

            return Ok(preferences);
        }

        // PUT: api/UserPreferences/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserPreferences(int id, [FromBody] UserPreferencesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedPreferences = await _userPreferencesService.UpdateUserPreferencesAsync(id, viewModel);
                return Ok(new { message = "Preferências atualizadas com sucesso!", updatedPreferences });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/UserPreferences/migrate
        [HttpPost("migrate")]
        public async Task<IActionResult> MigrateUserPreferences(int userIdFrom, int userIdTo)
        {
            try
            {
                await _userPreferencesService.MigrateUserPreferencesAsync(userIdFrom, userIdTo);
                return Ok(new { message = "Preferências migradas com sucesso!" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }

}
