using Api.Models;

namespace Api.Services.Teacher;

public interface ITeacherService
{
    public List<TeacherModel> RetrieveAll();

    public TeacherModel? FindById(long id);
}