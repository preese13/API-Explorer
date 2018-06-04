using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class Partner1IncomingPrimaryPayRateContext : DbContext
    {
        public Partner1IncomingPrimaryPayRateContext(DbContextOptions<Partner1IncomingPrimaryPayRateContext> options)
            : base(options)
        {
        }

        public DbSet<Partner1IncomingPrimaryPayRate> Partner1IncomingPrimaryPayRates { get; set; }

    }
}
