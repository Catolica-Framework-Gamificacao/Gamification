using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Services.Teacher;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }
    
    public List<TeacherModel> RetrieveAll()
    {
        return new List<TeacherModel>();
    }

    public TeacherModel? FindById(long id)
    {
        return null;
    }
}