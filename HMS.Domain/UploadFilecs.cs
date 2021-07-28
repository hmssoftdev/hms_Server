using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace HMS.Domain
{
  public class UploadFilecs:BaseEntity
    {
      
        public string Name { get; set; }
        public IFormFile files { get; set; }

      
    }
}
