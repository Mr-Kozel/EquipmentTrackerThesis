using System.ComponentModel.DataAnnotations;

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
        public string Phone { get; set; }
        public int Supervisor { get; set; }
        public bool Gender { get; set; }

    }
}
