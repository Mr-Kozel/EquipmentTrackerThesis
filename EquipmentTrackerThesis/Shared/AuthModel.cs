using System.ComponentModel.DataAnnotations;


namespace EquipmentTrackerThesis.Shared
{
    public class LoginResult
    {
        public string message { get; set; }
        public string email { get; set; }
        public string jwtBearer { get; set; }
        public bool success { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail cím megadása szükséges.")]
        [EmailAddress(ErrorMessage = "Helytelen e-mail cím.")]
        public string email { get; set; } // NOTE: email will be the username, too

        [Required(ErrorMessage = "Jelszó megadása szükséges.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
    public class RegModel : LoginModel
    {
        [Required(ErrorMessage = "Jelszó megerősítése szükséges.")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "A két jelszó nem egyezik meg.")]
        public string confirmpwd { get; set; }
    }
}
