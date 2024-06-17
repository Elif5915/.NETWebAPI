# File Mime Type Control NuGet Package

With this package, you can type-check **IFormFile** files for jpeg and png.
It checks bytes and if it fails, a **false** loop is made.


## Usage
```csharp
bool checkFileForJpeg = file.CheckForJpeg(); // Returns false if unsuccessful
bool checkFileForPng = file.CheckForPng();  //  Returns false if unsuccessful

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