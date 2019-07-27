using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [DefaultValue("false")]
        public bool isAdmin { get; set; }
       
        [DefaultValue("true")]
        public bool wanttodonate { get; set; }
        public string Name { get; set; }
        public string Email_address { get; set; }
        public string Login_Name { get; set; }
        public string BloodType { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
       public ICollection<Donation> donations { get; set; }
       
    }
}
