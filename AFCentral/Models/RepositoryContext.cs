using Microsoft.EntityFrameworkCore;

namespace AFCentral.Models
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
    : base(options)
        {
        }

        public DbSet<Repositories> Repositories { get; set; } = null!;
    }
}
