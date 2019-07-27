using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class Donation
    {
       public int DonationId { get; set; }
        public DateTime Dates { get; set; }
        public String Descriptions { get; set; }
        public String Addresses { get; set; }
        public DateTime Time_t { get; set; }
        public String Medical_Incharge { get; set; }
        public ICollection<User_Donation> User_Donations { get; set; }
    }
}
