using Fiap.Emailify.Data.Contexts;
using Fiap.Emailify.Models;
using Fiap.Emailify.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DatabaseContext _context;

        public EmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Email?> GetByIdAsync(int id)
        {
            return await _context.Emails.FindAsync(id);
        }

        public async Task<IEnumerable<Email>> GetAllAsync(string email)
        {
            var emails = await _context.Emails.ToListAsync();
            return emails
                .Where(e => e.Sender.Equals(email) || e.Recipients.Contains(email))
                .ToList();
        }

        public async Task AddAsync(Email email)
        {
            await _context.Emails.AddAsync(email);
            await SaveChangesAsync();
        }        

        public async Task DeleteAsync(int id)
        {
            var email = await GetByIdAsync(id);
            if (email != null)
            {
                _context.Emails.Remove(email);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}


