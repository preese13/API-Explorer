using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class IncomingDepartmentPositionContext : DbContext
    {
        public IncomingDepartmentPositionContext(DbContextOptions<IncomingDepartmentPositionContext> options)
            : base(options)
        {
        }

        public DbSet<IncomingDepartmentPosition> IncomingDepartmentPositions { get; set; }

    }
}