using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Model
{
    public class DetailRow
    {
        public string Title { get; set; }
        public List<string> Paragraphs { get; set; }

        public static DetailRow Make(string title, params string[] paragraphs)
        {
            return new DetailRow
            {
                Title = title,
                Paragraphs = paragraphs.ToList(),
            };
        }
    }
}
