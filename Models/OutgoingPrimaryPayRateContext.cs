using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class OutgoingPrimaryPayRateContext : DbContext
    {
        public OutgoingPrimaryPayRateContext(DbContextOptions<OutgoingPrimaryPayRateContext> options)
            : base(options)
        {
        }

        public DbSet<OutgoingPrimaryPayRate> OutgoingPrimaryPayRates { get; set; }

    }
}

