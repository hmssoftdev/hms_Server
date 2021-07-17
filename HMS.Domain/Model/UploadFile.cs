using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
   public class UploadFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile files { get; set; }
       
        public bool IsActive { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
    }
}
