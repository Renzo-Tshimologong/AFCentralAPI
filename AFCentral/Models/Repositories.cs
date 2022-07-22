using System.ComponentModel.DataAnnotations;

namespace AFCentral.Models
{
    public class Repositories
    {
        [Key]
        public string RepositoryId { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryDescription { get; set; }

        public string RepoLink { get; set; }
        public string CurriculumId { get; set; }
    }
}
