# File Mime Type Control NuGet Package

Bu paket ile requestten ald���n�z **IFormFile** dosyalar�n� jpeg ve png i�in type kontrol�ne tabi tutabilirsiniz.
Kontrol� byte �zerinden yapar ve e�er ba�ar�s�z olursa **false** d�n��� yap�l�r.


## Usage
```csharp
bool checkFileForJpeg = file.CheckForJpeg(); // ba�ar�s�z ise false d�ner
bool checkFileForPng = file.CheckForPng();  //  ba�ar�s�z ise false d�ner.
```

## Resource Code
```csharp
   public static bool CheckForJpeg(this IFormFile file) //jpeg kontrol�
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

    public static bool CheckForPng(this IFormFile file) //png kontrol�
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