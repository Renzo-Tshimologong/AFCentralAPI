

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCentral.Models
{
    public class StakeholderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StakeholdersId { get; set; }
        public string StakeholdersName { get; set; }
        public string StakeholderSurname { get; set; }

        public string StakeholderRole { get; set; }

        public string Contact { get; set; }

    }
}