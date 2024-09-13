using eCommerceHomeworkAPI.Abstractions;
using eCommerceHomeworkAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceHomeworkAPI.Controllers;
//[Route("api/[controller]/[action]")]
//[ApiController]
public sealed class OrderController : ApiController
{
    public static List<Order> orders = new();

    [HttpGet]

    public IActionResult GetAll()
    {
        return Ok(orders);
    }
}
