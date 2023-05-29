using Api.Repositories.Interfaces;
using Api.Services.Teacher;

namespace Api.Services.Subject;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _repository;
    private readonly ITeacherService _teacherService;
    public SubjectService(ISubjectRepository repository, ITeacherService teacherService)
    {
        _repository = repository;
        _teacherService = teacherService;
    }

    public List<Repository.Models.Database.Subject> GetAll()
    {
        return _repository.GetAll();
    }

    public Repository.Models.Database.Subject Save(Repository.Models.Database.Subject subject)
    {
        var teacher = _teacherService.FindById(subject.Teacher.Id);
        if (teacher == null)
        {
            throw new ArgumentException("Teacher not found.");
        }
        subject.Teacher = teacher;
        var entity = _repository.Save(subject);
        return entity;
    }

    public void Delete(string uuid)
    {
        _repository.Delete(uuid);
    }
}