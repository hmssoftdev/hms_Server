using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
    public class BaseEntity : IModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        public int UpdatedBy { get; set; }

    }

    public interface IModel
    {
         int Id { get; set; }
         bool IsActive { get; set; } 
         DateTime CreatedOn { get; set; } 
         int CreatedBy { get; set; }
         DateTime UpdatedOn { get; set; }
         int UpdatedBy { get; set; }
    }
}
