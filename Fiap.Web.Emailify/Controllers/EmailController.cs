using Fiap.Emailify.Services;
using Fiap.Emailify.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.API.Emailify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("get-emails/{email}")]
        public async Task<IActionResult> GetAllEmails(string email)
        {
            var emails = await _emailService.GetAllEmailsAsync(email);
            return Ok(emails);
        }

        [HttpGet("get-email-details")]
        public async Task<IActionResult> GetEmailById([FromQuery] string emailUser, [FromQuery] int idEmail)
        {
            try
            {
                var email = await _emailService.GetEmailByIdAsync(emailUser, idEmail);
                return Ok(email);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("send/{email}")]
        public async Task<IActionResult> SendEmail(string email, [FromBody] EmailSendViewModel emailViewModel)
        {
            try
            {
                await _emailService.SendEmailAsync(email, emailViewModel);
                return Ok("Enviado com Sucesso!");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
