using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreBloodBank.Classes
{
    public class User_Donation
    {
        [Key]
        [Column(Order = 1)]
        public int User_IdUser { get; set; }

        [Key]
        [Column(Order =2)]
        public int Donation_IdDonation { get; set; }
        public String Informations { get; set; }

        [ForeignKey("User_IdUser")]
        public User User { get; set; }

        [ForeignKey("Donation_IdDonation")]
        public Donation Donation { get; set; }

    }
}
