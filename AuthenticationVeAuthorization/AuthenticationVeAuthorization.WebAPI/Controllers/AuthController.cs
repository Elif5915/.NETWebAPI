using AuthenticationVeAuthorization.WebAPI.DTOs;
using AuthenticationVeAuthorization.WebAPI.Models;
using AuthenticationVeAuthorization.WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationVeAuthorization.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController : ControllerBase
{

    private List<User> Users = new();

    public AuthController()
    {

        byte[] passwordSalt, passwordHash;

        HashingHelper.CreatePassword("1", out passwordSalt, out passwordHash);

        User user = new()
        {

            Id = Guid.NewGuid(),
            FirstName = "Elif",
            LastName = "Yildirim",
            UserName = "Test",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt

        };
        Users.Add(user);

    }


    [HttpPost]
    public IActionResult Login(LoginDto request)
    {
        //user listemde bunu arayacağım
        User? user = Users.FirstOrDefault(p => p.UserName == request.UserName);
        if (user is null)
        {
            return BadRequest(new { Message = "User not found!" });
        }

        bool checkPassword = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!checkPassword)
        {
            return BadRequest(new { Message = "Password is wrong!!" });
        }
        //eğer varsa karşı tarafa giriş yaptığıma dair bir değer göndereceğim.
        return Ok(new { SecretKey = "MySecretSecretKey" });
    }
}
