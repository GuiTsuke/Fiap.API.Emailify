using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Sender { get; set; } = string.Empty;
        public List<string> Recipients { get; set; } = new ();
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
    }


}
