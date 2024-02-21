
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
        public List<Employee> GetAllEmployees()
        {
            return _dbcontext.Employee.ToList();
        }
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
        public void UpdateEmployee(Employee employee)
        {
            _dbcontext.Employee.Update(employee);
            _dbcontext.SaveChanges();
        }
    }
}
