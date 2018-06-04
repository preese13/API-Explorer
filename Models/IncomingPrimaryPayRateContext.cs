using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class IncomingPrimaryPayRateContext : DbContext
    {
        public IncomingPrimaryPayRateContext(DbContextOptions<IncomingPrimaryPayRateContext> options)
            : base(options)
        {
        }

        public DbSet<IncomingPrimaryPayRate> IncomingPrimaryPayRates { get; set; }

    }
}