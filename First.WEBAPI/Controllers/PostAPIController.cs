
using Microsoft.AspNetCore.Mvc;

namespace First.WEBAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PostAPIController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateDto request,int age, string name)
    {
        return NoContent();
    }

    [HttpPut]
    public IActionResult Update()
    {
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return NoContent();
    }
}

//class/record aslında tamamen aynı 

public sealed record CreateDto(UserDto userDto, CategoryDto categoryDto);
public sealed record UserDto(int Age,string Name,string Email); //primary constructor bu 

public sealed record CategoryDto(string Name);

//public sealed class UserDto //dto ları biz sadece bir kez kullanırız. 
//{
//    public UserDto(int age,string name,string email) {
//        Age = age;
//        Name = name;
//        Email = email;
//    }
//    public int Age { get; init; } //initler bir kere kullanılsın ve değiştirilemesin diye set yerine init yazarız.
//    public string Name { get; init; } = string.Empty;
//    public string? Email { get; init; }  // ? null olabilir demek istiyorsun ve "? = string.empty" aynı şeydir.
//}



//clean code da uyg. warning verir ve bunlar önemsenmez.
//<TreatWarningsAsErrors>true</TreatWarningsAsErrors>bunu proje verisyonun dosyasının oraya yazman yeterli. artık warninglerin error haline döner.
