using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly List<Email> _emails = new List<Email>();
        private readonly List<EmailLog> _emailLogs = new List<EmailLog>();

        public async Task<List<EmailViewModel>> GetAllEmailsAsync()
        {
            return await Task.FromResult(_emails.Select(e => new EmailViewModel
            {
                EmailId = e.EmailId,
                From = e.From,
                To = e.To,
                Subject = e.Subject,
                Body = e.Body,
                Timestamp = e.Timestamp
            }).ToList());
        }

        public async Task<EmailViewModel> GetEmailByIdAsync(string emailId)
        {
            var email = _emails.FirstOrDefault(e => e.EmailId == emailId);
            if (email == null)
            {
                return null;
            }

            return await Task.FromResult(new EmailViewModel
            {
                EmailId = email.EmailId,
                From = email.From,
                To = email.To,
                Subject = email.Subject,
                Body = email.Body,
                Timestamp = email.Timestamp
            });
        }

        public async Task SendEmailAsync(Email email)
        {
            _emails.Add(email);
            _emailLogs.Add(new EmailLog
            {
                UserEmail = email.From,
                SentAt = DateTime.UtcNow
            });

            await Task.CompletedTask;
        }

        public async Task<List<EmailLog>> GetEmailLogsByUserAsync(string userEmail, DateTime since)
        {
            return await Task.FromResult(
                _emailLogs.Where(log => log.UserEmail == userEmail && log.SentAt >= since).ToList()
            );
        }
    }
}


