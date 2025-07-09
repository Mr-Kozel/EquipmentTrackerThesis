using EquipmentTrackerThesis.Database;

namespace EquipmentTrackerThesis.Data
{
    public class RoleService
    {
        private DatabaseHandler _databaseHandler;
        /// <summary>
        /// This method creates connection to database handler.
        /// </summary>
        public RoleService (DatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }
        /// <summary>
        /// This method returns the role of the logged in user.
        /// </summary>
        /// <param name="username">The logged in user's unique reference.</param>
        /// <returns></returns>
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
