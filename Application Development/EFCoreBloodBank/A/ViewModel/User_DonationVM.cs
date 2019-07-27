using EFCoreBloodBank;
using EFCoreBloodBank.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.ViewModel
{
  public   class User_DonationVM
    {
        public Donation dond { get; set; }
        public User user { get; set; }

        List<Donation> dona = DonationVM.RetrieveallDon();

        public void UserDonation()
        {
            using(var db=new MyDbContext())
            {
                var st = dona.Join(UserVM.GetallUser(),
                    outerKey => outerKey.UserID,
                    innerKey => innerKey.UserId,
                    (dond,user) => new
                    {
                    dond.Addresses,
                    dond.Dates,
                    UserName=user.Name,
                    UserBlood=user.BloodType });
            }
        }

   
        
    }
}
