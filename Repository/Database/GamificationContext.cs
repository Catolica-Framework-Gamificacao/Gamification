using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Models.Database;
using ApplicationUser = Repository.Models.Database.User.ApplicationUser;

namespace Repository.Database;

public class GamificationContext : DbContext, IGamificationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder
            .UseNpgsql(AppConfiguration.DatabaseConnectionString,
                options => options.SetPostgresVersion(AppConfiguration.DatabaseMajorVersion,
                    AppConfiguration.DatabaseMinorVersion));
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ConfigureApplicationUser(builder);
        ConfigureStudent(builder);
        ConfigureTeacher(builder);
    }

    private static void ConfigureTeacher(ModelBuilder builder)
    {
        builder.Entity<Teacher>().HasNoKey();
    }

    private static void ConfigureStudent(ModelBuilder builder)
    {
        builder.Entity<Student>().Property(student => student.Ra).IsRequired();
        builder.Entity<Student>().HasIndex(student => student.Ra).IsUnique();
    }

    private static void ConfigureApplicationUser(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
            .HasIndex(user => new { user.Email, user.Password })
            .IsUnique();
    }

    public DatabaseFacade Database => base.Database;
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}