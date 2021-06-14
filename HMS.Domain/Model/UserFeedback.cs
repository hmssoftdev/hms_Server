using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
   public  class UserFeedback
    {
        public int Rating { get; set; }
        public string OpinionText { get; set; }
        public string ReviewTitle { get; set; }
        public bool TermsAccept { get; set; }
    }
}
