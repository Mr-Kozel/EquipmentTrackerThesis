using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EquipmentTrackerThesis.Database.Models
{
    public class JobTitle
    {
        [Key]
        public int JobTitleId { get; set; }
        public string? Description { get; set; }
        public int AccessCardType { get; set; }

        public string? Responsibilities { get; set; }
    }
}
