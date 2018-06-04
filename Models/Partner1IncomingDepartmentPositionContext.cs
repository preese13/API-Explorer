using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class Partner1IncomingDepartmentPositionContext : DbContext
    {
        public Partner1IncomingDepartmentPositionContext(DbContextOptions<Partner1IncomingDepartmentPositionContext> options)
            : base(options)
        {
        }

        public DbSet<Partner1IncomingDepartmentPosition> Partner1IncomingDepartmentPositions { get; set; }

    }
}
