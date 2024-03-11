
using EquipmentTrackerThesis.Data;
using EquipmentTrackerThesis.Database.Models;

namespace EquipmentTrackerThesis.Database
{
    public class DatabaseHandler
    {
        private readonly DatabaseContext _dbcontext;
        public DatabaseHandler(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region ACCESSCARDS - tested

        /// <summary>
        /// This method lists all accesscards in the table.
        /// </summary>
        /// <returns></returns>
        public List<AccessCard> GetAllAccessCards()
        {
            return _dbcontext.AccessCard.ToList();
        }
        /// <summary>
        /// This method adds a row to AccessCard table.
        /// </summary>
        /// <param name="accessCard">The data you want to add.</param>
        public void AddNewAccessCard(AccessCard accessCard)
        {
            _dbcontext.AccessCard.Add(accessCard);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method removes the selcted row from AccessCard table.
        /// </summary>
        /// <param name="accessCard">The row of the selected accesscard.</param>
        public void DeleteAccessCard(AccessCard accessCard)
        {
            _dbcontext.AccessCard.Remove(accessCard);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method updates the selected data(s) of an accesscard.
        /// </summary>
        /// <param name="accessCard">The row of the selected accesscard</param>
        public void UpdateAccessCard(AccessCard accessCard)
        {
            _dbcontext.AccessCard.Update(accessCard);
            _dbcontext.SaveChanges();
        }

        #endregion

        #region DEVICES - tested

        /// <summary>
        /// This method lists all devices in the table.
        /// </summary>
        /// <returns></returns>
        public List<Devices> GetAllDevices()
        {
            return _dbcontext.Devices.ToList();
        }
        /// <summary>
        /// This method adds a row to Devices table.
        /// </summary>
        /// <param name="device">The data you want to add.</param>
        public void AddNewDevice(Devices device)
        {
            _dbcontext.Devices.Add(device);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method removes the selcted row from Devices table.
        /// </summary>
        /// <param name="device">The row of the selected device.</param>
        public void DeleteDevice(Devices device)
        {
            _dbcontext.Devices.Remove(device);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method updates the selected data(s) of a device.
        /// </summary>
        /// <param name="device">The row of the selected device</param>
        public void UpdateDevice(Devices device)
        {
            _dbcontext.Devices.Update(device);
            _dbcontext.SaveChanges();
        }

        #endregion

        #region EMPLOYEES - tested

        /// <summary>
        /// This method lists all employees in the table.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            return _dbcontext.Employee.ToList();
        }
        /// <summary>
        /// This method adds a row to Employee table.
        /// </summary>
        /// <param name="employee">The data you want to add.</param>
        public void AddNewEmployee(Employee employee)
        {
            _dbcontext.Employee.Add(employee);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method removes the selcted row from Employee table.
        /// </summary>
        /// <param name="employee">The row of the selected employee.</param>
        public void DeleteEmployee(Employee employee)
        {
            _dbcontext.Employee.Remove(employee);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method updates the selected data(s) of an employee.
        /// </summary>
        /// <param name="employee">The row of the selected employee</param>
        public void UpdateEmployee(Employee employee)
        {
            _dbcontext.Employee.Update(employee);
            _dbcontext.SaveChanges();
        }

        #endregion

        #region JOBTITLE  tested

        /// <summary>
        /// This method lists all jobtitles in the table.
        /// </summary>
        /// <returns></returns>
        public List<JobTitle> GetAllJobTitles()
        {
            return _dbcontext.JobTitle.ToList();
        }
        /// <summary>
        /// This method adds a row to JobTitle table.
        /// </summary>
        /// <param name="jobTitle">The data you want to add.</param>
        public void AddNewJobTitle(JobTitle jobTitle)
        {
            _dbcontext.JobTitle.Add(jobTitle);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method removes the selcted row from JobTitle table.
        /// </summary>
        /// <param name="jobTitle">The row of the selected job title.</param>
        public void DeleteJobTitle(JobTitle jobTitle)
        {
            _dbcontext.JobTitle.Remove(jobTitle);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method updates the selected data(s) of a job title.
        /// </summary>
        /// <param name="jobTitle">The row of the selected employee</param>
        public void UpdateJobTitle(JobTitle jobTitle)
        {
            _dbcontext.JobTitle.Update(jobTitle);
            _dbcontext.SaveChanges();
        }

        #endregion

        #region LOGIN

        /// <summary>
        /// This method lists all logins in the table.
        /// </summary>
        /// <returns></returns>
        public List<Login> GetAllLogins()
        {
            return _dbcontext.Login.ToList();
        }
        /// <summary>
        /// This method adds a row to Login table.
        /// </summary>
        /// <param name="login">The data you want to add.</param>
        public void AddNewLogin(Login login)
        {
            _dbcontext.Login.Add(login);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method removes the selcted row from Login table.
        /// </summary>
        /// <param name="login">The row of the selected login.</param>
        public void DeleteLogin(Login login)
        {
            _dbcontext.Login.Remove(login);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// This method updates the selected data(s) of a login.
        /// </summary>
        /// <param name="login">The row of the selected login</param>
        public void UpdateLogin(Login login)
        {
            _dbcontext.Login.Update(login);
            _dbcontext.SaveChanges();
        }

        #endregion

    }
}
