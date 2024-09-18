using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Services
{
    public interface ISpamControlService
    {
        Task<bool> IsSpam(string sender);
    }
}
