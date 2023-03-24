using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database.User;

namespace Api.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    public IGamificationContext Context { get; set; }

    public ApplicationUserRepository(IGamificationContext context)
    {
        this.Context = context;
    }

    public void Save(UserModel user)
    {
        var applicationUser = new ApplicationUser
        {
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            Type = user.Type,
            UpdateDate = DateTime.UtcNow
        };

        Context.Users.Add(applicationUser);
        Context.SaveChanges();
    }

    public Task<List<ApplicationUser>> GetAll()
    {
        return Task.FromResult(Context.Users.ToList());
    }

    public ApplicationUser? GetByKey(string email, string password)
    {
        return Context.Users.Any() ? Context.Users.SingleOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password)) : null;
    }
}