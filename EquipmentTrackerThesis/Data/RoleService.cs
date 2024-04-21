using EquipmentTrackerThesis.Database;
using EquipmentTrackerThesis.Database.Models;

namespace EquipmentTrackerThesis.Data
{
    public class RoleService
    {
        private DatabaseHandler _databaseHandler;
        public RoleService (DatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }
        public string GetRole(string username)
        {
            var logins = _databaseHandler.GetAllLogins();
            var foundUser = logins.FirstOrDefault(x => x.Username == username);
            if (foundUser != null && foundUser.Role == "Admin")
            {
                return "Admin";
            }
            else
            {
                return "Employee";
            }
        }
    }
}
