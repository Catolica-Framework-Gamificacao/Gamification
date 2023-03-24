using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database;

namespace Api.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IGamificationContext _context;

    public TeacherRepository(IGamificationContext context)
    {
        _context = context;
    }
    
    public List<Teacher> GetAll()
    {
        return _context.Teachers.ToList();
    }
}