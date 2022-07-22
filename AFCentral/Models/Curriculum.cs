using System.ComponentModel.DataAnnotations;

namespace AFCentral.Models
{
    public class Curriculum
    {
        [Key]
        public string CurriculumId { get; set; }
        public string CurriculumName { get; set; }
        public string CurriculumDescription { get; set; }

        public string ProgrammeId { get; set; }
    }
}
