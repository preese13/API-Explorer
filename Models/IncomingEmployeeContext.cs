using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class IncomingEmployeeContext : DbContext
    {
        public IncomingEmployeeContext(DbContextOptions<IncomingEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<IncomingEmployee> IncomingEmployees { get; set; }

    }
}