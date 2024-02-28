namespace EquipmentTrackerThesis.Database.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public DateTimeOffset LastLogin { get; set; }
        //TODO: adatbázisba konvertálást megoldani
    }
}
