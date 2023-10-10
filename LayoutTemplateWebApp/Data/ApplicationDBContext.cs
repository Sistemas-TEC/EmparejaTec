using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Data
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            
        }

        public DbSet<AppUser> AppUser { get; set; }
    }
}
