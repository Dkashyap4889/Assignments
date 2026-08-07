using Microsoft.AspNetCore.Mvc;
using MiddlewareDemo.Authentication;

namespace MiddlewareDemo.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenGenerator _tokenGenerator;

    public AuthController(JwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // Fake users
        if (request.Username == "admin" &&
            request.Password == "123")
        {
            var token = _tokenGenerator.GenerateToken(
                1,
                "admin",
                "Admin");

            return Ok(new
            {
                Token = token
            });
        }

        if (request.Username == "user" &&
            request.Password == "123")
        {
            var token = _tokenGenerator.GenerateToken(
                2,
                "user",
                "User");

            return Ok(new
            {
                Token = token
            });
        }

        return Unauthorized("Invalid username or password.");
    }
}