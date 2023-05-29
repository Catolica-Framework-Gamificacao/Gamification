using Repository.Database;
using Repository.Models.Database;

namespace Api.Repositories.Interfaces;

public interface IStudentRepository
{
    public List<Student> GetAll();
    public Student Save(Student student);
    public Student Save(Student student, IGamificationContext context);
}