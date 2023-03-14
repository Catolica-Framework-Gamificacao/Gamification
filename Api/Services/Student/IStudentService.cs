using Api.Models;

namespace Api.Services.Student;

public interface IStudentService
{
    public List<StudentModel> RetriveAll();
}