using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
   public class UploadFile
    {
        public int Id { get; set; }
        public IFormFile files { get; set; }
        public string Name { get; set; }
    }
}
