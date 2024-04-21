namespace EquipmentTrackerThesis.Database.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime LastLogin { get; set; }
        public string Role { get; set; } = "Employee";
    }
}
