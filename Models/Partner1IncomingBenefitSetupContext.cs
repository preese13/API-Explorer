using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class Partner1IncomingBenefitSetupContext : DbContext
    {
        public Partner1IncomingBenefitSetupContext(DbContextOptions<Partner1IncomingBenefitSetupContext> options)
            : base(options)
        {
        }

        public DbSet<Partner1IncomingBenefitSetup> Partner1IncomingBenefitSetups { get; set; }

    }
}
