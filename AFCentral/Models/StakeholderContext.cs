using Microsoft.EntityFrameworkCore;
namespace AFCentral.Models
{
    public class StakeholderContext: DbContext
    {
        public StakeholderContext(DbContextOptions<StakeholderContext> options)
            : base(options)
        {
        }

        public DbSet<StakeholderItem> StakeholderItems { get; set; } = null!;
    }
}
