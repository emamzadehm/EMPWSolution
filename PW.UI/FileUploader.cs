using _01_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PW.UI
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _iwebhostenvironment;

        public FileUploader(IWebHostEnvironment iwebhostenvironment)
        {
            _iwebhostenvironment = iwebhostenvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            string directoryPath;
            directoryPath = $"{_iwebhostenvironment.WebRootPath}//Uploads//{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}
