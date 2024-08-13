using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.WEBAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class FilesController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromForm] List<IFormFile> files)
    {
        //buradaki dosyaları cloud üzerine ya da ftp, byte[] çevirip db kaydedebiliyorsun.ya da backend klasörüne kaydedebilirsin..
        // önce backend kalsörüne kaydetmeye odaklanalım.

        foreach (var file in files)
        {

         #region Dosyaya kaydetme

            // 1.yol :  dosyaların isimlendirmesi unique olmasını sağları. yoksa her sabit isimde yeni farklı gelen dosyaları birbirininb üzerine yazar.

            // string fileFormat = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            // string fileName = Guid.NewGuid().ToString() + fileFormat;

            var now = DateTime.Now.Ticks + "-" + file.FileName; //2.yol 

            using (var stream = System.IO.File.Create("wwwroot/" + file.FileName))
            {
                file.CopyTo(stream);
            }
        }
        #endregion

        #region Byte[] array çevirme ile DB kaydetme

        //foreach (var file in files)
        //{
        //    using (var memorySteam = new MemoryStream())
        //    {
        //        file.CopyTo(memorySteam);
        //        var fileBytes = memorySteam.ToArray();
        //        string fileString = Convert.ToBase64String(fileBytes);
        //    }
        //}

        #endregion



        return NoContent();
    }
}
