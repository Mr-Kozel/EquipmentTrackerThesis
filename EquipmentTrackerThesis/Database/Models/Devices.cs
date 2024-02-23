using System.ComponentModel.DataAnnotations;

namespace EquipmentTrackerThesis.Database.Models
{
    public class Devices
    {
        [Key]
        public int Assignment { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Type  { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int Owner { get; set; }
        public DateOnly ReceptionDate { get; set; }
        public DateOnly ReturnDate { get; set; }

    }
}
