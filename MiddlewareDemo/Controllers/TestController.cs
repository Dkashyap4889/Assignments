using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace MiddlewareDemo.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [EnableRateLimiting("api")]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Get()
        {
            return Ok("Hello from Controller");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("Welcome Admin!");
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new Exception("Database connection failed.");
        }
    }
}
