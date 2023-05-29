using Repository.Database;

namespace Api.Services.Student;

public interface IStudentService
{
    public List<Repository.Models.Database.Student> RetriveAll();
    public Repository.Models.Database.Student Save(Repository.Models.Database.Student student);
    public Repository.Models.Database.Student Save(Repository.Models.Database.Student student, IGamificationContext context);
}