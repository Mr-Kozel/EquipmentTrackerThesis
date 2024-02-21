using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentTrackerThesis.Database.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int JobTitle { get; set; }
        public int Phone { get; set; }
        public int Supervisor { get; set; }

    }
}
