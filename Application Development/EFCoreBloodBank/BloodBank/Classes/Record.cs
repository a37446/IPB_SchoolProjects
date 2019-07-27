using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class Record
    {
        public int RecordId { get; set; }
        public String Info { get; set; }
        public int User_IdUser { get; set; }
        public int Donation_IdDonation { get; set; }
    }
}
