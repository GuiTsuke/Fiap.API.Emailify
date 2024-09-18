using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.ViewModels
{
    public class CustomizeThemeRequest
    {
        public string Email { get; set; } = string.Empty;
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public List<string>? Labels { get; set; }
        public List<string>? Categories { get; set; }
        public bool IsDarkTheme { get; set; }
    }
}
