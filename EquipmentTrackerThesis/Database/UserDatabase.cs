using System.Net.NetworkInformation;
using System;
using System.Security.Cryptography;
using System.Text;
using EquipmentTrackerThesis.Database;
using EquipmentTrackerThesis.Database.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Identity;

namespace EquipmentTrackerThesis.Database
{
    public class User
    {
        public string Email { get; }
        public User(string email)
        {
            Email = email;
        }
    }
    public interface IUserDatabase
    {
        Task<User> AuthenticateUser(string email, string password);
        Task<User> AddUser(string email, string password);
    }

    public class UserDatabase : IUserDatabase
    {
        private readonly IWebHostEnvironment env;
        public UserDatabase(IWebHostEnvironment env) => this.env = env;
        private static string CreateHash(string password)
        {
            var salt = "997eff51db1544c7a3c2ddeb2053f052";
            var md5 = new HMACSHA256(Encoding.UTF8.GetBytes(salt + password));
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return System.Convert.ToBase64String(data);
        }
        public async Task<User> AuthenticateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;
            var hashedPass = CreateHash(password);
            var users = _databaseHandler.GetAllLogins();
            foreach ( var user in users )
            {
                if(await user.Email == email && user.Password == hashedPass )
                {
                    return new User(email);
                }
            }

            /*var path = System.IO.Path.Combine(env.ContentRootPath, "Users");
            if (!System.IO.Directory.Exists(path))
                return null;
            path = System.IO.Path.Combine(path, email);
            if (!System.IO.File.Exists(path))
                return null;
            if (await System.IO.File.ReadAllTextAsync(path) != CreateHash(password))
                return null;*/
            
        }
        public async Task<User> AddUser(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    return null;
                
                var addLogin = new Login
                {
                    Username = email,
                    Password = CreateHash(password),
                    LastLogin = DateTime.Now
                };

                await _databaseHandler.AddNewLogin(addLogin);
                
                /*var path = System.IO.Path.Combine(env.ContentRootPath, "Users"); // NOTE: THIS WILL CREATE THE "USERS" FOLDER IN THE PROJECT'S FOLDER!!!
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path); // NOTE: MAKE SURE THERE ARE CREATE/WRITE PERMISSIONS
                path = System.IO.Path.Combine(path, email);
                if (System.IO.File.Exists(path))
                    return null;
                await System.IO.File.WriteAllTextAsync(path, CreateHash(password));
                return new User(email);*/
            }
            catch
            {
                return null;
            }
        }
    }
}
