using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Services.Student;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }
    public List<StudentModel> RetriveAll()
    {
        var students = this._repository.GetAll();
        return students;
    }
}