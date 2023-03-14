using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Models.Database;
using ApplicationUser = Repository.Models.Database.User.ApplicationUser;

namespace Repository.Database;

public class GamificationContext : DbContext, IGamificationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(AppConfiguration.DatabaseConnectionString,
                options => options.SetPostgresVersion(AppConfiguration.DatabaseMajorVersion,
                    AppConfiguration.DatabaseMinorVersion));
    }
    
    public DatabaseFacade Database => base.Database;
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}