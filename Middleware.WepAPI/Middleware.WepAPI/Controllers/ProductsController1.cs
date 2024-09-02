using Microsoft.AspNetCore.Mvc;

namespace Middleware.WepAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ProductsController1 : ControllerBase
{
    [HttpGet]
    public IActionResult Calculate()
    {
        //int x = 0;
        //int y = 0;
        //int z = x / y;

        throw new Exception("bu bir exception hatası");
        throw new ArgumentException("bu bir exception hatası");
        throw new ArgumentException("bu bir excepiton hatası");

        //ürün adı daha önce olmuş.
        throw new MyException();

        return NoContent();
    }
}



public class MyException : Exception
{

}
