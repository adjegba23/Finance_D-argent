using System.ComponentModel.DataAnnotations;

namespace Finance_D_argent.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
