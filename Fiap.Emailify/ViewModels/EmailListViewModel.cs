using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.ViewModels
{
    public class EmailListViewModel
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsSent { get; set; }
    }

}
