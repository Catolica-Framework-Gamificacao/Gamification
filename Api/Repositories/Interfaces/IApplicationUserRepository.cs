using Api.Models;
using Repository.Models.Database.User;

namespace Api.Repositories.Interfaces;

public interface IApplicationUserRepository
{
    void Save(UserModel user);
    Task<List<ApplicationUser>> GetAll();
}