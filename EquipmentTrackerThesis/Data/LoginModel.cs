using EquipmentTrackerThesis.Database.Models;

namespace EquipmentTrackerThesis.Data
{
    public class LoginModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
