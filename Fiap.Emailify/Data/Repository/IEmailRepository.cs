using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public interface IEmailRepository
    {
        Task<List<EmailViewModel>> GetAllEmailsAsync();
        Task<EmailViewModel> GetEmailByIdAsync(string emailId);
        Task SendEmailAsync(Email email);
        Task<List<EmailLog>> GetEmailLogsByUserAsync(string userId, DateTime since);
    }
}
