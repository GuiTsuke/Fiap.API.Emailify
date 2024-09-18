using Fiap.Emailify.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public class SpamControlService : ISpamControlService
    {
        private readonly DatabaseContext _context;
        private readonly TimeSpan _spamLimitPeriod = TimeSpan.FromMinutes(5); // Período de controle de spam
        private readonly int _maxEmailsPerPeriod = 5; // Máximo de e-mails permitidos por período

        public SpamControlService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> IsSpam(string sender)
        {
            var now = DateTime.UtcNow;

            // Obtém a contagem de e-mails enviados pelo remetente no período de controle de spam
            var recentEmailCount = await _context.Emails
                .Where(e => e.Sender == sender && e.SentDate >= now - _spamLimitPeriod)
                .CountAsync();

            // Verifica se a contagem excede o limite
            return recentEmailCount >= _maxEmailsPerPeriod;
        }
    }

}
