using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName(); 
            if (file.Length > 0) 
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create)) 
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file); 
            File.Move(sourcepath, result); 
            return result;
        }

        public static void Delete(string path)
        {
            try
            {
                File.Delete(path); 
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public static string Update(string sourcePath, IFormFile file) 
        {
            var result = newPath(file); 
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream); 
                }
            }
            File.Delete(sourcePath); 
            return result;
        }

        public static string newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName); 
            string fileExtension = fileInfo.Extension; 
            string path = Path.Combine(Environment.CurrentDirectory, "Images");
            string newPath = Guid.NewGuid().ToString() + fileExtension; 
            string result = Path.Combine(path, newPath);
            return result;

        }
    }
}