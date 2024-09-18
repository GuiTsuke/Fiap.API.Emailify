using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Models
{
    public class UserPreferences
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Theme { get; set; }
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public string LabelsJson { get; set; } = "[]"; // Armazenará Labels como JSON
        public string CategoriesJson { get; set; } = "[]"; // Armazenará Categories como JSON

        public bool IsDarkTheme { get; set; }
        public bool IsActive { get; set; }

    }
}
