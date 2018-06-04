using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class Partner1DeductionContext : DbContext
    {
        public Partner1DeductionContext(DbContextOptions<Partner1DeductionContext> options)
            : base(options)
        {
        }

        public DbSet<Partner1Deduction> Partner1Deductions { get; set; }

    }
}
