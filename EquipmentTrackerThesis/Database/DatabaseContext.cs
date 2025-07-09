using EquipmentTrackerThesis.Database.Models;
using EquipmentTrackerThesis.Database;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using EquipmentTrackerThesis.Data;

namespace EquipmentTrackerThesis.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AccessCard>? AccessCard { get; set; }
        public DbSet<Devices>? Devices { get; set; }
        public DbSet<Employee>? Employee { get; set; }
        public DbSet<JobTitle>? JobTitle { get; set; }
        public DbSet<Login>? Login { get; set; }

        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        
        /// <summary>
        /// This method creates models from the database 
        /// .
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessCard>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });
            modelBuilder.Entity<Devices>(entity =>
            {
                entity.HasIndex(e => e.Assignment).IsUnique();
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });
            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.HasIndex(e => e.JobTitleId).IsUnique();
            });
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });
        }
        /// <summary>
        /// Make a hashed version of the given password.
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            var salt = "997eff51db1544c7a3c2ddeb2053f052";
            var md5 = new HMACSHA256(Encoding.UTF8.GetBytes(salt + password));
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// This method check if a correct username and password pair have been entered. If yes signes in the user and fill the Employee Model with it's data. The method uses the hashed version of the entered password. 
        /// </summary>
        /// <param name="username">Entered username</param>
        /// <param name="hashedpass">Hashed version of the entered password</param>
        /// <param name="dbHandler">Database connection</param>
        /// <returns></returns>
        public EmployeeModel? SignedInEmployee(string username, string hashedpass, DatabaseHandler dbHandler)
        {
            var currentEmployee = Login?.FirstOrDefault(login => login.Username == username && login.Password == hashedpass);
            if (currentEmployee == null)
            {
                return null;
            }
            else
            {
                //Search the user in the database and get their personal data.
                var employees = dbHandler.GetAllEmployees();
                var employee = Employee?.FirstOrDefault(employee => employee.Id == currentEmployee.Id - 1);
                if (employee != null && employee.IsActive == false)
                {
                    return null;
                }
                else
                {
                    //If the user is existing and active the method creates an Employee Model.
                    return new EmployeeModel
                    {
                        Employee = employees[(currentEmployee.Id - 1)],
                        Username = username
                    };
                }
            }
        }

    }
}
