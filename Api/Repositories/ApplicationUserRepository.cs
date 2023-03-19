using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database.User;

namespace Api.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private IGamificationContext Context { get; set; }

    public ApplicationUserRepository(IGamificationContext context)
    {
        this.Context = context;
    }

    public void Save(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task<List<ApplicationUser>> GetAll()
    {
        return Task.FromResult(Context.Users.ToList());
    }
}