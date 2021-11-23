using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace studentinfoportal.API.Repositores
{
    public class LocalImageUploadRepository : IImageUploadRepository
    {
        public async Task<string> Upload(IFormFile fileImage, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await fileImage.CopyToAsync(fileStream);
            return GetRelativeFilePathForServer(fileName);

        }
        private string GetRelativeFilePathForServer(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
