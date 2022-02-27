using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Finance_D_argent.Models
{
    public class ErrorTable
    {
        [Key]
        public int ID { get; set; }

        public string Message { get; set; }
        
    }
}
