using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Models;

namespace TASK_8_11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet <Category> categories { get; set; }
        public DbSet <Supplier> supply {  get; set; }
        public DbSet<Product> product { get; set; }
    }
}
