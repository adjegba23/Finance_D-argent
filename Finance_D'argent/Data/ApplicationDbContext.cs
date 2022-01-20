using Finance_D_argent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finance_D_argent.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
