using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Models.Database;
using ApplicationUser = Repository.Models.Database.User.ApplicationUser;

namespace Repository.Database;

public class GamificationContext : DbContext, IGamificationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine(AppConfiguration.DatabaseConnectionString);
        optionsBuilder
            .UseNpgsql(AppConfiguration.DatabaseConnectionString,
                options => options.SetPostgresVersion(AppConfiguration.DatabaseMajorVersion,
                    AppConfiguration.DatabaseMinorVersion));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(user => new { user.Email, user.Password })
            .IsUnique();
    }
    
    public DatabaseFacade Database => base.Database;
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}