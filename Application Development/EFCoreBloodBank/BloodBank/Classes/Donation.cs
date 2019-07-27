using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class Donation
    {

        public int DonationId { get; set; }
        public DateTime Dates { get; set; }
        public string Descriptions { get; set; }
        public string Addresses { get; set; }
        public DateTime Time_t { get; set; }
        public string Medical_Incharge { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }

      
    }
}
