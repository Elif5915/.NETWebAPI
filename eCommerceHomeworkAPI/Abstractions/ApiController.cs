using Microsoft.AspNetCore.Mvc;

namespace eCommerceHomeworkAPI.Abstractions;
[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{   //artık benim inherit alabileceğim ApiController isminde abstract sınıfım var.
    //bir classı inherit aldığınız zaman tüm özellikleri ile birlikte alırsın 
}
