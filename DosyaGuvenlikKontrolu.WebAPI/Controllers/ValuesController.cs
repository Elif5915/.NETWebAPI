using Microsoft.AspNetCore.Mvc;

namespace DosyaGuvenlikKontrolu.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpPost] // eğer bir dosya istiyorsak get ile yakalayamayız, sebebi şu formfile istiyoruz ve dosyamız obje ondan dolayı post metodu ile olur. 

    public IActionResult SaveFile([FromForm] IFormFile file)
    {
        //jpeg ve png formatlarını bekliyorum!

        //jpg ve png formatlarını bekliyoruz ve onu destekliyoruz diyelim sadece senaryoda!
        //137,80,78,71 => png byte array değerleri
        //255,216,255 => jpeg
        //77,90,144 => exe

        bool checkFile = file.CheckFileForJpg();

        //using (var stream = new MemoryStream()) //dosyamızı byte array dönüştürmek için önce memory alırız sonra byte çevirip ekrana basarız.
        //{
        //    file.CopyTo(stream); //artık dosyam memory de
        //    byte[] fileBytes = stream.ToArray(); //ismi değiştirebilrsin ama asla buradaki 3-8 haneli kısmı asla değiştiremezsin format yazan kısmı!

        //}

        return NoContent();
    }

}

public static class Extensions
{
    public static bool CheckFileForJpg(this IFormFile file)
    {
        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            byte[] fileBytes = stream.ToArray();
            string jpgValue = fileBytes[0].ToString() + fileBytes[1].ToString() + fileBytes[2].ToString();

            if (jpgValue != "255216255")
            {
                return false;
            }
        }

        return true;
    }
}