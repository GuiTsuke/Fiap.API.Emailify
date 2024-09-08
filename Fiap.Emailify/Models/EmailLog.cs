using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Emailify.Models
{
    public class EmailLog
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime SentAt { get; set; }
    }

}
