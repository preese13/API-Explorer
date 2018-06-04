using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class Partner1IncomingEmployeeStatusContext : DbContext
    {
        public Partner1IncomingEmployeeStatusContext(DbContextOptions<Partner1IncomingEmployeeStatusContext> options)
            : base(options)
        {
        }

        public DbSet<Partner1IncomingEmployeeStatus> Partner1IncomingEmployeeStatuses { get; set; }

    }
}
