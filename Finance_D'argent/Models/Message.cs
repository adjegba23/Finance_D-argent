using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Finance_D_argent.Models
{
    public class Message
    {
        [Required]
        [EmailAddress]
        public string ToEmail { get; set; }
        [Required]
        [EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
