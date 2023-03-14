using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database;

namespace Api.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IGamificationContext Context;

    public TeacherRepository(IGamificationContext context)
    {
        Context = context;
    }
    
    public List<Teacher> GetAll()
    {
        return Context.Teachers.ToList();
    }
}