using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.ViewModels
{
    public class CalendarEventViewModel
    {
        public string EventId { get; set; }

        [Required(ErrorMessage = "O campo 'Title' é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo 'Date' é obrigatório.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O campo 'Description' é obrigatório.")]
        public string Description { get; set; }
    }
}
