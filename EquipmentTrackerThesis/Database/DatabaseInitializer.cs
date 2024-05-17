using Microsoft.Data.SqlClient;
using System.Text;

namespace EquipmentTrackerThesis.Database
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    if (!DatabaseExists(connection, "ManagementSystemDB"))
                    {
                        ExecuteSqlScript(connection, "ManagementSystemDB.sql");
                        Console.WriteLine("Database created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Database already exists.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private bool DatabaseExists(SqlConnection connection, string databaseName)
        {
            string query = $"SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = '{databaseName}'";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }

        private void CreateDatabase(SqlConnection connection, string databaseName)
        {
            string query = $"CREATE DATABASE {databaseName}";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecuteSqlScript(SqlConnection connection, string scriptFileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string scriptFilePath = Path.Combine(currentDirectory, scriptFileName);
            Console.WriteLine($"Executing script from: {scriptFilePath}"); // Debug statement

            if (!File.Exists(scriptFilePath))
            {
                Console.WriteLine($"Error: Script file not found at {scriptFilePath}");
                return;
            }

            string script;
            using (StreamReader reader = new StreamReader(scriptFilePath, Encoding.GetEncoding(1250)))
            {
                script = reader.ReadToEnd();
            }
    
            string[] statements = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

            SqlCommand cmd = new SqlCommand(script, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
