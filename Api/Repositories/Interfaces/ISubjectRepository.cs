using Repository.Models.Database;

namespace Api.Repositories.Interfaces;

public interface ISubjectRepository
{
    public List<Subject> GetAll();
    public Subject Save(Subject subject);
    public void Delete(string uuid);
}