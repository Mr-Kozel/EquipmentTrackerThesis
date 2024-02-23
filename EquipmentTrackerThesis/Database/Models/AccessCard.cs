using System.ComponentModel.DataAnnotations;

namespace EquipmentTrackerThesis.Database.Models
{
    public class AccessCard
    {
        [Key]
        public int Id { get; set; }
        public bool MainBuilding { get; set; }
        public bool Laborathory { get; set; }
        public bool ProductionSite { get; set; }
        public bool Warehouse { get; set; }
        public bool HazardWarehouse { get; set; }
        public bool DevelopementCenter { get; set; }
        public bool CountrsideSite { get; set; }

    }
}
