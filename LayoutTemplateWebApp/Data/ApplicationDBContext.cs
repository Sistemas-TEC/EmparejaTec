using EmparejaTecWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace EmparejaTecWebApp.Data
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Interest> Interest { get; set; }

        public DbSet<AppUserXInterest> AppUserXInterest { get; set; }

        public DbSet<UserPossibleMatch> UserPossibleMatch { get; set; }
    }
}
