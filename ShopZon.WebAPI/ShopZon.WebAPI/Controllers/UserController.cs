using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopZon.WebAPI.Dtos;
using ShopZon.WebAPI.Models;
using ShopZon.WebAPI.Utilities;

namespace ShopZon.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class UserController : ControllerBase
{
    public static List<User> Users { get; set; } = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Users);
    }

    [HttpPost]
    public IActionResult CreateUser( CreateUserDto request)
    {
        string fileName = request.File.FileName.CreateFileName();

        using (var stream = System.IO.File.Create($"wwwroot/users/{fileName}"))
        {
            request.File.CopyTo(stream);

        }
        User user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            CreateAt = DateTime.Now,
            UserPhotoUrl = fileName
        };

        Users.Add(user);

        return Created();

    }
}
