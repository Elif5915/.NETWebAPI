# File Mime Type Control NuGet Package

Bu paket ile requestten aldýðýnýz **IFormFile** dosyalarýný jpeg ve png için type kontrolüne tabi tutabilirsiniz.
Kontrolü byte üzerinden yapar ve eðer baþarýsýz olursa **false** dönüþü yapýlýr.


## Usage
```csharp
bool checkFileForJpeg = file.CheckForJpeg(); // baþarýsýz ise false döner
bool checkFileForPng = file.CheckForPng();  //  baþarýsýz ise false döner.
```

## Resource Code
```csharp
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
```