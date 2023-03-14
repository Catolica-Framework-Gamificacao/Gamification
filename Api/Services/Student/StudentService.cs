using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Services.Student;

public class StudentService : IStudentService
{
    private readonly IStudentRepository Repository;

    public StudentService(IStudentRepository repository)
    {
        Repository = repository;
    }
    public List<StudentModel> RetriveAll()
    {
        var students = this.Repository.GetAll();
        return students;
    }
}