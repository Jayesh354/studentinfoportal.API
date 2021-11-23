using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentinfoportal.API.Repositores
{
    public interface IImageUploadRepository
    {
        Task<string> Upload(IFormFile fileImage, string fileName);
    }
}
