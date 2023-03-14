using Api.Models.Login;
using Api.Models.Register;
using Api.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Database.User;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService Service;

    public AuthController(IAuthService authService)
    {
        this.Service = authService;
    }

    [HttpPost]
    [Route("login")]
    public ActionResult<ApplicationUser> Login([FromBody] Credential credential)
    {
        var response = this.Service.Authenticate(credential);

        if (response.Success)
        {
            return Ok(response.User);
        }
        else
        {
            return Unauthorized(response.Error);
        }
    }

    [HttpPost]
    [Route("register")]
    public ActionResult<string> Register([FromBody] Formulary formulary)
    {
        var response = this.Service.Register(formulary);

        if (response.Success)
        {
            return Ok(response.User);
        }
        else
        {
            return BadRequest(response.Error);
        }
    }
}