using Repository.Models.Database;

namespace Api.Repositories.Interfaces;

public interface ITeacherRepository
{
    public List<Teacher> GetAll();
    
    Teacher? FindById(long id);
}