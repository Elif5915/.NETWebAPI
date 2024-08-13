using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace First.WEBAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
//[EnableRateLimiting("Fixed")] // tüm controller daki endpointlerde uygulamak istersen, eğer bunu da yapmayıp tüm uygulamadaki apı lerde uygulamak istersen program.cs ayar yapılır.
public sealed class TodosController : ControllerBase

    // bu yapı action ve hangi parametereler kullanılıyor vs bu görünmediği için swagger da. ama bazı yazılımcılar böyle kullanır. 
{
    [HttpPost]
    public IActionResult Create(UserDto request)
    {
        // var context = HttpContext;
        return NoContent();
    }
    [HttpGet]
    //[EnableRateLimiting("Fixed")] // endpointe uygulamak istersen
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        // await Task.Delay(3000); bazen uygulamanı bir süre uyutmak istersen de kullanılır bu şekilde.
        return NoContent();
    }
    [HttpPut] // güncelleme işlemlerini temsil eder ama illa güncelleme yapacaksın diye bir kontrol yok içinde silme de olabilir,uygulama bunu bilemez
    public IActionResult Update()
    {
        return NoContent();
    }
    [HttpDelete("{id}")] // silme işlemleri temsili
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
