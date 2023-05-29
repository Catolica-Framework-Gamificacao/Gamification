using System.Data;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Repository.Database;
using Repository.Models.Database;

namespace Api.Repositories;

public class SubjectRepository : ISubjectRepository
{
    
    private readonly IGamificationContext _context;

    public SubjectRepository(IGamificationContext context)
    {
        _context = context;
    }
    
    public List<Subject> GetAll()
    {
        return _context.Subjects.ToList();
    }

    public Subject Save(Subject subject)
    {
        var uuid = subject.Uuid.IsNullOrEmpty() ? Guid.NewGuid().ToString() : subject.Uuid;
        var entity = _context.Subjects.Add(new Subject()
        {
            Uuid = uuid,
            Name = subject.Name,
            UpdateDate = DateTime.UtcNow
        }).Entity;
        _context.SaveChanges();
        return entity;
    }

    public void Delete(string uuid)
    {
        var subject = _context.Subjects.FirstOrDefault(subject => subject.Uuid.Equals(uuid));

        if (subject == null) throw new DataException("Subject not found.");
        
        _context.Subjects.Remove(subject);
        _context.SaveChanges();
    }
}