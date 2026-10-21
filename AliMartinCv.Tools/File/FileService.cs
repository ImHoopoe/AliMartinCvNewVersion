using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Tools
{
    public static class FileService
    {
        public static async Task<string> SaveImage(this IFormFile file,string dir)
        {
            string path = Directory.GetCurrentDirectory() + dir;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (file == null || file.Length == 0)
            {
                return null;
            }
            string[] allowedExtension = { ".png", ".jpeg", ".jpg", ".webp", ".gif" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtension.Contains(fileExtension))
            {
                return null;
            }
            if (file.Length > 5 * 1024 * 1024)
            {
                return null;
            }
            string fileName = $"{Guid.NewGuid().ToString().Replace("-", "")}{fileExtension}";
            path = Path.Combine(path, fileName);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(fs);
                    return fileName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }

            }

        }
        public static bool DeleteImage(string ImageName)
        {
            if (string.IsNullOrEmpty(ImageName))
            {
                return false;
            }
            string path = Directory.GetCurrentDirectory() + "/wwwroot/" + "/Images/" + "/Articles/" + ImageName;
            if (!File.Exists(path))
            {
                return false;
            }
            File.Delete(path);
            return true;
        }
    }
}
