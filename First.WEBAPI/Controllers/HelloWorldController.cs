using Microsoft.AspNetCore.Mvc; //contollerbase bu kütüphaneden gelir.mvc projelerinde sadece contoller olur base kelimesi olmaz.

namespace First.WEBAPI.Controllers;

//sealed keywordü: sadece başka classlar tarafından bu classı inherit edebilmesini engeller. sadece inherit engellemek güvenlik için

// [Route("api/HelloWorld")] 
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class HelloWorldController : ControllerBase
{
    [HttpGet] 
    public IActionResult Test(int age,string name)
    {
        return Ok(new { Message = "API is working..." }); 
        // string gönderdiğin bir şey canlı da default => json döndüğü için 200 status code hataları alırsın.
        //onun için strin ifadeni json formatına çevirmek için objeye çevirrisin new il ve sonra ona keyword vererek api gönderirsin.
         
    }

    // [HttpGet("[action]")] // hangi tipteyse isimsiz olarak sadece 1 tip olarak. İsim veriyorsak onu unique olarak vermeliyiz.  
    [HttpGet]
    public IActionResult  Test2()
    {
        return Ok("Elif yıldırım...");
    } 

}
