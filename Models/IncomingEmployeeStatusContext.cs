using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class IncomingEmployeeStatusContext : DbContext
    {
        public IncomingEmployeeStatusContext(DbContextOptions<IncomingEmployeeStatusContext> options)
            : base(options)
        {
        }

        public DbSet<IncomingEmployeeStatus> IncomingEmployeeStatuses { get; set; }

    }
}