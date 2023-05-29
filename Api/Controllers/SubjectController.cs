using Api.Models;
using Api.Services.Student;
using Api.Services.Subject;
using Api.Services.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]  
[ApiController]
[Route("subject")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _service;
    private readonly ITeacherService _teacherService;
    private readonly IStudentService _studentService;

    public SubjectController(ISubjectService service, ITeacherService teacherService, IStudentService studentService)
    {
        _service = service;
        _teacherService = teacherService;
        _studentService = studentService;
    }
    
    [HttpGet]
    [Route("all")]
    public ActionResult<SubjectModel> All()
    {
        return Ok(_service.GetAll());
    }
    
    [HttpPost]
    [Route("new")]
    public ActionResult<SubjectModel> New([FromBody] SubjectModel model)
    {
        var subject = model.ToEntity();
        var entity = _service.Save(subject);
        model = SubjectModel.Load(entity);
        return Ok(model);
    }
    
    [HttpPut]
    [Route("update/{id}")]
    public ActionResult<SubjectModel> Update([FromRoute] long id, [FromBody] SubjectModel model)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<string> Delete([FromRoute] string uuid)
    {
        _service.Delete(uuid);
        return Ok(uuid);
    }
    
    # region TEACHER
    [HttpGet]
    [Route("teacher/{id}/subjects")]
    public ActionResult<List<SubjectModel>> FindSubjectsByTeacher([FromRoute] long id)
    {
        if (id == null)  return BadRequest("Teacher id cannot be null");
        var teacher = _teacherService.FindById(id);
        if (teacher == null) BadRequest("Teacher not found.");
        return BadRequest();
    }

    #endregion

    #region STUDENT

    [HttpGet]
    [Route("student/{id}/subjects")]
    public ActionResult<List<SubjectModel>> FindSubjectsByStudent([FromRoute] long id)
    {
        if (id == null)  return BadRequest("Student id cannot be null");
        return BadRequest();
    }

    #endregion

}