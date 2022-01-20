using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_D_argent.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public string? RoleId { get; set; }

        [NotMapped]
        public string? Role { get; set; }
    }
}
