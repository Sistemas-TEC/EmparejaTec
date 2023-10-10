using LayoutTemplateWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Data
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Student { get; set; }
    }
}
