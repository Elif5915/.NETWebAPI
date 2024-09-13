using eCommerceHomeworkAPI.Abstractions;
using eCommerceHomeworkAPI.Dtos;
using eCommerceHomeworkAPI.Models;
using eCommerceHomeworkAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceHomeworkAPI.Controllers;
//[Route("api/[controller]/[action]")]
//[ApiController]
public class AuthController : ApiController
{

    private static List<User> Users = new();

    [HttpPost]
    public IActionResult Register(RegisterDto request)
    {
        //aynı user 2 defa ekleyememek lazım
        bool isUserNameExist = Users.Any(p => p.UserName == request.UserName);

        if (isUserNameExist)
        {
            // return BadRequest(new { Message = "Username is already exists..." });
            var errorResponse = Result.Failed("Username is already exists..");
            return BadRequest(errorResponse);
        }

        User user = new User() //instance oluşturduk.
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Password = request.Password
        };

        Users.Add(user);

        // return Ok(new { Message = "user create is successful..." });
        return Ok(Result.Succeed("user create is successful..."));
    }

    [HttpPost]
    public IActionResult Login(LoginDto request)
    {
        User? user = Users.FirstOrDefault(p => p.UserName == request.UserName);
        if (user is null)
        {
            // return BadRequest(new { Message = "User not found!" });
            return BadRequest(Result.Failed("User not found"));
        }

        if (user.Password != request.Password)
        {
            return BadRequest(Result.Failed("Password is wrong.."));
        }

        string token = "Token";
        return Ok(Result.Succeed(token));
    }
}
