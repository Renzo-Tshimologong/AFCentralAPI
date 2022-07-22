using Microsoft.EntityFrameworkCore;
namespace AFCentral.Models
{
    public class CurriculumContext: DbContext
    {
        public CurriculumContext(DbContextOptions<CurriculumContext> options)
      : base(options)
        {
        }

        public DbSet<Curriculum> Curriculums { get; set; } = null!;
    }
}
