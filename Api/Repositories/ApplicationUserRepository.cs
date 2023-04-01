using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database.User;

namespace Api.Repositories;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private IGamificationContext _context { get; set; }

    public ApplicationUserRepository(IGamificationContext context)
    {
        _context = context;
    }

    public void Save(UserModel user)
    {
        int type = UserTypeModel.GetLogicalByUserType(user.UserType.Type);
        var applicationUser = new ApplicationUser
        {
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            Type = type,
            UpdateDate = DateTime.UtcNow
        };

        _context.Users.Add(applicationUser);
        _context.SaveChanges();
    }

    public Task<List<ApplicationUser>> GetAll()
    {
        return Task.FromResult(_context.Users.ToList());
    }

    public ApplicationUser? GetByKey(string email, string password)
    {
        return _context.Users.Any() ? _context.Users.SingleOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password)) : null;
    }
}