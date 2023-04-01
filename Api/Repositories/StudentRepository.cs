using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;

namespace Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IGamificationContext _context;

    public StudentRepository(IGamificationContext context)
    {
        _context = context;
    }
    
    public List<StudentModel> GetAll()
    {
        List<StudentModel> models = new();
        var students = _context.Students.ToList();
        foreach (var student in students)
        {
            
        }

        return models;
    }
}