using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Task>().Property(t => t.Title).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Task>().Property(t => t.Description).HasMaxLength(1000);
            modelBuilder.Entity<Task>().Property(t => t.Status).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Username).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.FullName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Role).HasMaxLength(50).IsRequired();
        }
    }
}
