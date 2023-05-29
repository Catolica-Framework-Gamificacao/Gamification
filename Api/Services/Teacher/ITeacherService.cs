using Repository.Database;

namespace Api.Services.Teacher;

public interface ITeacherService
{
    public List<Repository.Models.Database.Teacher> RetrieveAll();

    public Repository.Models.Database.Teacher? FindById(long? id);

    Repository.Models.Database.Teacher Save(Repository.Models.Database.Teacher teacher);
    
    Repository.Models.Database.Teacher Save(Repository.Models.Database.Teacher teacher, IGamificationContext context);
    
}