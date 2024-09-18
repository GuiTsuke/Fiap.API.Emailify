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
        Task<IEnumerable<EmailListViewModel>> GetAllEmailsAsync(string email);
        Task<EmailDetailViewModel> GetEmailByIdAsync(string emailUser, int idEmail);
        Task SendEmailAsync(string email, EmailSendViewModel emailViewModel);

    }
}
