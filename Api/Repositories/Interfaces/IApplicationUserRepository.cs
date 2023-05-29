using Repository.Database;
using Repository.Models.Database.User;

namespace Api.Repositories.Interfaces;

public interface IApplicationUserRepository
{
    ApplicationUser Save(ApplicationUser user, IGamificationContext context);
    ApplicationUser Save(ApplicationUser user);
    Task<List<ApplicationUser>> GetAll();
    ApplicationUser? GetByKey(string email, string password);
}