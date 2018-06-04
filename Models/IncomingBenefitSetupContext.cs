using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class IncomingBenefitSetupContext : DbContext
    {
        public IncomingBenefitSetupContext(DbContextOptions<IncomingBenefitSetupContext> options)
            : base(options)
        {
        }

        public DbSet<IncomingBenefitSetup> IncomingBenefitSetups { get; set; }

    }
}