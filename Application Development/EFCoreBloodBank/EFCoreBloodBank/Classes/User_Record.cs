using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class User_Record
    {
       
        [Key]
        [Column(Order = 1)]
        public int User_IdUser { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Record_IdRecord { get; set; }

        [ForeignKey("Record_IdRecord")]
        public Record Record{ get; set; }
        [ForeignKey("User_IdUser")]
        public User User { get; set; }
    }
}
