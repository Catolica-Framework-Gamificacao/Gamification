using Api.Models.Auth;
using Api.Models.Login;
using Api.Models.Register;
using Api.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService authService)
    {
        this._service = authService;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public ActionResult<AuthenticationResponse> Login([FromBody] Credential credential)
    {
        var response = _service.Authenticate(credential);

        if (response.Success)
        {
            return Ok(response);
        }
        else
        {
            return Unauthorized(response);
        }
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("register")]
    public ActionResult<RegisterResponse> Register([FromBody] Formulary formulary)
    {
        var response = _service.Register(formulary);

        if (response.Success)
        {
            return Ok(response.User);
        }
        else
        {
            return BadRequest(response);
        }
    }
}