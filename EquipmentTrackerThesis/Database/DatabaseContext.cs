using EquipmentTrackerThesis.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentTrackerThesis.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        //TODO: DbSet<Table>.....
        public DatabaseContext()
        {
            
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });
        }
    }
}
