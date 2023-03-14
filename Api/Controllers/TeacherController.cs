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
    private readonly ITeacherService Service;

    public TeacherController(ITeacherService teacherService)
    {
        this.Service = teacherService;
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<List<Teacher>> RetrieveAll()
    {
        return BadRequest();
    }
}