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

    public ApplicationUser Save(ApplicationUser user)
    {
        return Save(user, _context);
    }

    public ApplicationUser Save(ApplicationUser user, IGamificationContext context)
    {
        var entity = context.Users.Add(user).Entity;
        return entity;
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