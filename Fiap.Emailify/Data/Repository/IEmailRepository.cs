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
        Task<Email?> GetByIdAsync(int id);
        Task<IEnumerable<Email>> GetAllAsync(string email);
        Task AddAsync(Email email);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }

}
