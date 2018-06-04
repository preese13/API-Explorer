using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class OutgoingDepartmentPositionContext : DbContext
    {
        public OutgoingDepartmentPositionContext(DbContextOptions<OutgoingDepartmentPositionContext> options)
            : base(options)
        {
        }

        public DbSet<OutgoingDepartmentPosition> OutgoingDepartmentPositions { get; set; }

    }
}