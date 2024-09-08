using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.ViewModels
{
    public class UserPreferencesViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public string PrimaryColor { get; set; }

        [Required]
        public string SecondaryColor { get; set; }
    }

}
