using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Middleware.WepAPI.Filters;

namespace Middleware.WepAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    [Log]

    public IActionResult Method(int age)
    {
        var context = HttpContext;
        return Ok(new { Message = "Apı is working.." });

    }

    [HttpPost]
    [Log]

    public IActionResult Method1(User user)
    {
        var context = HttpContext;
        return Ok(new { Message = "Apı is working..", Note = "Something" });

    }

}

public class User
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
