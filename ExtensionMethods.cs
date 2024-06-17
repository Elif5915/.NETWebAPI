using Microsoft.AspNetCore.Http;

namespace EY.FileMimeTypeControl;
public static class ExtensionMethods
{
    public static bool CheckForJpeg(this IFormFile file) //jpeg kontrolü
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

    public static bool CheckForPng(this IFormFile file) //png kontrolü
    {
        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            byte[] fileBytes = stream.ToArray();
            string pngValue = fileBytes[0].ToString() + fileBytes[1].ToString() + fileBytes[2].ToString() + fileBytes[3].ToString();

            if (pngValue != "137807871")
            {
                return false;
            }
        }
        return true;

    }
}

