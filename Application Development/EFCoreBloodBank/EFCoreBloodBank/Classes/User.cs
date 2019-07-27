using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Email_address { get; set; }

        public string Login_Name { get; set; }

        public string Password { get; set; }
        public string Medical_Report { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
       public ICollection<User_Donation> User_Donations { get; set; }
        public ICollection<User_Record> User_Records { get; set; }
    }
}
