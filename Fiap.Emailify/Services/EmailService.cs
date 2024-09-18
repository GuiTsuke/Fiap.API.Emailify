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
        private readonly IEmailRepository _emailRepository;
        private readonly ISpamControlService _spamControlService;

        public EmailService(IEmailRepository emailRepository, ISpamControlService spamControlService)
        {
            _emailRepository = emailRepository;
            _spamControlService = spamControlService;
        }

        public async Task<IEnumerable<EmailListViewModel>> GetAllEmailsAsync(string email)
        {
            var emails = await _emailRepository.GetAllAsync(email);
            return emails.Select(e => new EmailListViewModel
            {
                Id = e.Id,
                Sender = e.Sender,
                Recipients = e.Recipients,
                Subject = e.Subject,
                SentDate = e.SentDate,
                IsSent = e.Sender == email
            });
        }

        public async Task<EmailDetailViewModel> GetEmailByIdAsync(string emailUser, int idEmail)
        {
            var email = await _emailRepository.GetByIdAsync(idEmail);
            if (email == null || (email.Sender != emailUser && !email.Recipients.Contains(emailUser)))
            {
                throw new KeyNotFoundException("E-mail não encontrado!");
            }
            return new EmailDetailViewModel
            {
                Id = email.Id,
                Sender = email.Sender,
                Recipients = email.Recipients,
                Subject = email.Subject,
                Body = email.Body,
                SentDate = email.SentDate,
                IsSent = email.Sender == emailUser
            };
        }

        public async Task SendEmailAsync(string emailSender, EmailSendViewModel emailViewModel)
        {
            // Verifica controle de spam
            if (await _spamControlService.IsSpam(emailSender))
            {
                throw new InvalidOperationException("Envio de e-mail com restrições por suspeita de spam");
            }

            var email = new Email
            {
                Sender = emailSender,
                Recipients = emailViewModel.Recipients,
                Subject = emailViewModel.Subject,
                Body = emailViewModel.Body,
                SentDate = DateTime.UtcNow
            };

            await _emailRepository.AddAsync(email);
        }
    }

}
