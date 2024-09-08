using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.ViewModels
{
    public class EmailViewModel
    {
        public string EmailId { get; set; }

        [Required(ErrorMessage = "O campo 'From' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo 'From' deve conter um endereço de e-mail válido.")]
        public string From { get; set; }

        [Required(ErrorMessage = "O campo 'To' é obrigatório.")]
        [EmailAddress(ErrorMessage = "Todos os endereços no campo 'To' devem ser válidos.")]
        public List<string> To { get; set; }

        [Required(ErrorMessage = "O campo 'Subject' é obrigatório.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "O campo 'Body' é obrigatório.")]
        public string Body { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
