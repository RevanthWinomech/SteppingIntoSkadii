using Authentication.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
         
        public DbSet<Employee> Employees { get; set; }
    }
}
