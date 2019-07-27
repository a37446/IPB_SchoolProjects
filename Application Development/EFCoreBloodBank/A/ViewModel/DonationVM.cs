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
    public class DonationVM
    {

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Donation> Donations { get; set; }



        public void AddDonation(Donation donation)
        {
            using (var db = new MyDbContext())
            {
                db.Donation.Add(donation);
                db.SaveChanges();
            }

        }

        public void Retrieve()
        {
            using (var db = new MyDbContext())
            {
                Donations = new ObservableCollection<Donation>(db.Donation);

                /*
                var query=(from p in db.User
                             join r in db.Donation
                             on p.UserId equals r.UserID
                             select new { r,p });
*/
            }
        }

        public static List<Donation> RetrieveallDon()
        {
            using (var db = new MyDbContext())
            {
                return db.Donation.ToList();
            }
        }
    }
}
