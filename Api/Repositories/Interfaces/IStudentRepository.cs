
using Api.Models;

namespace Api.Repositories.Interfaces;

public interface IStudentRepository
{
    public List<StudentModel> GetAll();
}