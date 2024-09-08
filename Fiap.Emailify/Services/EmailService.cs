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
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _repository;
        private readonly int _emailLimit = 10;
        private readonly TimeSpan _timeSpanLimit = TimeSpan.FromHours(1);

        public EmailService(IEmailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmailViewModel>> GetAllEmailsAsync()
        {
            return await _repository.GetAllEmailsAsync();
        }

        public async Task<EmailViewModel> GetEmailByIdAsync(string emailId)
        {
            return await _repository.GetEmailByIdAsync(emailId);
        }

        public async Task<(bool blocked, string message)> SendEmailAsync(EmailViewModel emailViewModel)
        {
            // Verificar frequência de envio
            var logs = await _repository.GetEmailLogsByUserAsync(emailViewModel.From, DateTime.UtcNow - _timeSpanLimit);
            if (logs.Count >= _emailLimit)
            {
                return (true, "Você atingiu o limite de envio de e-mails por hora.");
            }

            // Enviar e-mail
            var email = new Email
            {
                EmailId = Guid.NewGuid().ToString(),
                From = emailViewModel.From,
                To = emailViewModel.To,
                Subject = emailViewModel.Subject,
                Body = emailViewModel.Body,
                Timestamp = DateTime.UtcNow
            };

            await _repository.SendEmailAsync(email);

            return (false, "E-mail enviado com sucesso.");
        }
    }
}
