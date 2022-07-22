using Microsoft.EntityFrameworkCore;
namespace AFCentral.Models
{
    public class ProgrammeContext : DbContext
    {
        public ProgrammeContext(DbContextOptions<ProgrammeContext> options)
            : base(options)
        {
        }

        public DbSet<Programme> Programmes { get; set; } = null!;
    }
}
