using Microsoft.EntityFrameworkCore;

namespace mockAPI.Models
{
    public class DeductionContext : DbContext
    {
        public DeductionContext(DbContextOptions<DeductionContext> options)
            : base(options)
        {
        }

        public DbSet<Deduction> Deductions { get; set; }

    }
}