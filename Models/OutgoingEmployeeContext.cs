using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class OutgoingEmployeeContext : DbContext
    {
        public OutgoingEmployeeContext(DbContextOptions<OutgoingEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<OutgoingEmployee> OutgoingEmployees { get; set; }

    }
}

