using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BloodBank.Classes
{
    public class News
    {

      

        [Key]
        public int NewsId { get; set; }
      
        public string Title { get; set; }

        public string details { get; set; }
        public string CoverImage { get; set; }
    }
}
