using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Model
{
    public class TotalRow
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Inverse { get; set; }

        public static TotalRow Make(string name, decimal value, bool inverse = false)
        {
            return new TotalRow()
            {
                Name = name,
                Value = value,
                Inverse = inverse,
            };
        }
    }
}
