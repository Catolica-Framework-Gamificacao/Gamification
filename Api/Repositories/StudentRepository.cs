using Api.Repositories.Interfaces;
using Repository.Database;
using Repository.Models.Database;

namespace Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IGamificationContext _context;

    public StudentRepository(IGamificationContext context)
    {
        _context = context;
    }
    
    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public Student Save(Student student, IGamificationContext context)
    {
        return context.Students.Add(student).Entity;
    }

    public Student Save(Student student)
    {
        return Save(student, _context);
    }
}