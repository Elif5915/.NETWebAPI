using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationVeAuthorization.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProductsController : ControllerBase
{
    [HttpGet]
    // [MyAutthorize]
    [Authorize(AuthenticationSchemes = "MyAuthScheme")]
    public IActionResult GetAll()
    {
        return Ok();
    }
}
