using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class OutgoingBenefitSetupContext : DbContext
    {
        public OutgoingBenefitSetupContext(DbContextOptions<OutgoingBenefitSetupContext> options)
            : base(options)
        {
        }

        public DbSet<OutgoingBenefitSetup> OutgoingBenefitSetups { get; set; }

    }
}