using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;

namespace Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IGamificationContext Context;

    public StudentRepository(IGamificationContext context)
    {
        Context = context;
    }
    
    public List<StudentModel> GetAll()
    {
        List<StudentModel> s = new();
        var students = Context.Students.ToList();
        foreach (var student in students)
        {
            
        }

        return s;
    }
}