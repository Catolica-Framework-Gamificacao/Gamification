using Api.Models;
using Repository.Database;
using Repository.Models.Database.User;

namespace Api.Services.User;

public interface IApplicationUserService
{
    ApplicationUser Save(UserModel user, IGamificationContext context);
    ApplicationUser Save(UserModel user);
    Task<List<ApplicationUser>> GetAll();
    ApplicationUser? GetByKey(string email, string password);
}