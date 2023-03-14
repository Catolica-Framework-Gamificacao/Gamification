using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Models.Database;
using ApplicationUser = Repository.Models.Database.User.ApplicationUser;

namespace Repository.Database;

public interface IGamificationContext
{
    DatabaseFacade Database { get; }
    DbSet<ApplicationUser> Users { get; set; }
    DbSet<Student> Students { get; set; }
    DbSet<Subject> Subjects { get; set; }
    DbSet<Teacher> Teachers { get; set; }
    int SaveChanges();
}