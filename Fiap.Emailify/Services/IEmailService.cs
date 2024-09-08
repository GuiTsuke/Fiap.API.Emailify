using Fiap.Emailify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public interface IEmailService
    {
        Task<List<EmailViewModel>> GetAllEmailsAsync();
        Task<EmailViewModel> GetEmailByIdAsync(string emailId);
        Task<(bool blocked, string message)> SendEmailAsync(EmailViewModel emailViewModel);

    }
}
