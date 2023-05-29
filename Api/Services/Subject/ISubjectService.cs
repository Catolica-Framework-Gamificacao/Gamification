namespace Api.Services.Subject;

public interface ISubjectService
{
    public List<Repository.Models.Database.Subject> GetAll();
    public Repository.Models.Database.Subject Save(Repository.Models.Database.Subject subject);
    public void Delete(string uuid);
}