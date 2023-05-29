using Api.Repositories.Interfaces;
using Repository.Database;

namespace Api.Services.Student;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }
    public List<Repository.Models.Database.Student> RetriveAll()
    {
        return _repository.GetAll();
    }

    public Repository.Models.Database.Student Save(Repository.Models.Database.Student student)
    {
        return _repository.Save(student);
    }

    public Repository.Models.Database.Student Save(Repository.Models.Database.Student student, IGamificationContext context)
    {
        return _repository.Save(student, context);
    }
}