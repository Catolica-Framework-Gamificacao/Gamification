using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database.User;

namespace Api.Services.User;

public class ApplicationUserService : IApplicationUserService
{
    private readonly IApplicationUserRepository _repository;

    public ApplicationUserService(IApplicationUserRepository repository)
    {
        _repository = repository;
    }
    public ApplicationUser Save(UserModel user, IGamificationContext context)
    {
        return _repository.Save(user.ToEntity(), context);
    }

    public ApplicationUser Save(UserModel user)
    {
        return _repository.Save(user.ToEntity());
    }

    public Task<List<ApplicationUser>> GetAll()
    {
        return _repository.GetAll();
    }

    public ApplicationUser? GetByKey(string email, string password)
    {
        return _repository.GetByKey(email, password);
    }
}