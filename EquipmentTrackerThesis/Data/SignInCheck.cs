using EquipmentTrackerThesis.Database;
using System.Data;


namespace EquipmentTrackerThesis.Data
{
    public class SignInCheck
    {
        private DatabaseContext _dbcontext;
        private DatabaseHandler _databaseHandler;
        private RoleService roleService;
        public EmployeeModel? CurrentEmployee { get; set; }

        public SignInCheck(DatabaseContext dbcontext, DatabaseHandler databaseHandler)
        {
            _dbcontext = dbcontext;
            _databaseHandler = databaseHandler;
        }
        
        public bool SignInAttempt(string username, string password)
        {
            string hashedpass = _dbcontext.HashPassword(password);
            CurrentEmployee = _dbcontext.SignedInEmployee(username, hashedpass, _databaseHandler);
            if (CurrentEmployee == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string GetRole()
        {
            roleService = new RoleService(_databaseHandler);
            return roleService.GetRole(CurrentEmployee?.Username ?? "");
        }
    }
}
