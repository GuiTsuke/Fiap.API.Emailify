using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Models
{
    public class UserPreferences
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Theme { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Labels { get; set; }

    }
}
