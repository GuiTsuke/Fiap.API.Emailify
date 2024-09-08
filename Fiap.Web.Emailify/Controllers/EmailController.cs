using Fiap.Emailify.Services;
using Fiap.Emailify.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.API.Emailify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // GET: api/emails
        [HttpGet]
        public async Task<IActionResult> GetAllEmails()
        {
            var emails = await _emailService.GetAllEmailsAsync();
            return Ok(emails);
        }

        // GET: api/emails/{emailId}
        [HttpGet("{emailId}")]
        public async Task<IActionResult> GetEmailById(string emailId)
        {
            var email = await _emailService.GetEmailByIdAsync(emailId);
            if (email == null)
            {
                return NotFound();
            }
            return Ok(email);
        }

        // POST: api/emails/send
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailViewModel emailViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (blocked, message) = await _emailService.SendEmailAsync(emailViewModel);

            if (blocked)
            {
                return BadRequest(new { status = "blocked", message });
            }

            return Ok(new { status = "success", message });
        }
    }
}
