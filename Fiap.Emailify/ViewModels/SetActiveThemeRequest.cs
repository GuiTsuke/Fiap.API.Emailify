using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.ViewModels
{
    public class SetActiveThemeRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
    }
}
