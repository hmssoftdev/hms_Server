using HMS.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<string> Upload([FromForm] UploadFile obj)
        {
            if (obj.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\Images\\" + obj.files.FileName))
                    {
                        obj.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\" + obj.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}
