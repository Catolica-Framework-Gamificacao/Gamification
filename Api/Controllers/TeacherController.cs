using Api.Models;
using Api.Services.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Database;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("teacher")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<List<Teacher>> RetrieveAll()
    {
        return Ok(_service.RetrieveAll());
    }

    [HttpGet]
    [Route("{id}/students")]
    public ActionResult<List<UserModel>> FindStudentsByTeacher([FromRoute] long id)
    {
        if (id == null) return BadRequest("Teacher id cannot be null");
        var teacher = _service.FindById(id);
        if (teacher == null) BadRequest("Teacher not found.");
        
        return BadRequest();
    }
}