using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class Partner2DeductionContext : DbContext
    {
        public Partner2DeductionContext(DbContextOptions<Partner2DeductionContext> options)
            : base(options)
        {
        }

        public DbSet<Partner2Deduction> Partner2Deductions { get; set; }

    }
}
