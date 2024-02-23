using EquipmentTrackerThesis.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentTrackerThesis.Database
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<AccessCard> AccessCard { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<Login> Login { get; set; }

        public DatabaseContext()
        {
            
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
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
        

    }
}
