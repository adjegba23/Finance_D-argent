using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Finance_D_argent.Models
{
    public class Loginviewmodel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set;}

    }
}
