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

    public TeacherController(ITeacherService teacherService)
    {
        this._service = teacherService;
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<List<Teacher>> RetrieveAll()
    {
        return BadRequest();
    }
}