using Api.Models;
using Api.Repositories.Interfaces;
using Repository.Database;

namespace Api.Services.Teacher;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }
    
    public List<Repository.Models.Database.Teacher> RetrieveAll()
    {
        return new List<Repository.Models.Database.Teacher>();
    }

    public Repository.Models.Database.Teacher? FindById(long? id)
    {
        if (id == null)
        {
            throw new ArgumentException("Teacher id cannot be null");
        }

        return _repository.FindById((long) id);
    }

    public Repository.Models.Database.Teacher Save(Repository.Models.Database.Teacher teacher)
    { 
        return _repository.Save(teacher);
    }

    public Repository.Models.Database.Teacher Save(Repository.Models.Database.Teacher teacher, IGamificationContext context)
    {
        return _repository.Save(teacher, context);
    }
}