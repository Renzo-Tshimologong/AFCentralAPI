using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCentral.Models
{
    public class Programme
    {
        [Key]
        public string ProgrammeId { get; set; }
        public string ProgrammeName { get; set; }  
        public string ProgrammeDescription { get; set; }

       public string StakeholdersId { get; set; }
    }
}
