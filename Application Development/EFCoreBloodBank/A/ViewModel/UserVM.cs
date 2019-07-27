using A.pages;
using EFCoreBloodBank;
using EFCoreBloodBank.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;

namespace A.ViewModel
{

    public class UserVM : MainViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }
        readonly MyDbContext _dbContext = new MyDbContext();
        public User users { get; set; }
        public Login log { get; set; }
        public Authentication auth { get; set; }
        public Donation don { get; set; }

        public UserVM()
        {

        }


        public void AddUser(User user)
        {
            using (var db = new MyDbContext())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        public void RetrieveAll()
        {
            using (var db = new MyDbContext())
            {
                Users = new ObservableCollection<User>(db.User.Where(a => a.wanttodonate == false));
            }
        }



        public bool Checkwantstodonate(string username, string pass)
        {

            using (var db = new MyDbContext())
            {
                var user = new User();
                return user.wanttodonate = (from q in db.User where (q.Login_Name == username && q.Password == pass) select q.wanttodonate).Single();

            }

        }


        public void RetrieveById(int ID)
        {
            using (var DB = new MyDbContext())
            {
                Users = new ObservableCollection<User>(DB.User.Where(b => b.UserId == ID));
            }
        }

        public void Retrievebybloodtype(string BloodType)
        {
            using (var db = new MyDbContext())
            {
                Users = new ObservableCollection<User>(db.User.Where(b => b.BloodType == BloodType && b.wanttodonate==false));
                //var user = db.User.Where(b => b.BloodType == BloodType);
            }
        }

        public ObservableCollection<User> RetrievebyUsernameAndPassword(string login, string pass)
        {
            using (var db = new MyDbContext())
            {
                Users = new ObservableCollection<User>(db.User.Where(b => b.Login_Name == login && b.Password == pass));

            }
            return Users;

        }





        public async void SendEmail(string toreceipient)
        {


            EmailMessage objEmail = new EmailMessage();
            objEmail.To.Add(new EmailRecipient(toreceipient));
            objEmail.Body = "You are a match for this rare blood group, please" +
              " if you want to help" + "  " +
              "Contanct him/her by replying to this email" + " Thankyou!  ";

            objEmail.Subject = "Request for an Blood Donation";


            await EmailManager.ShowComposeNewEmailAsync(objEmail);
        }



        public User RetrieveByUserPw(User users)
        {
            using (var db = new MyDbContext())
            {

                return (from p in Users
                        where p.Login_Name == log.loginname()
                        where p.Password == log.passreturn()
                        select p
                        ).SingleOrDefault();

            }

        }

        public int RetrieveUserID(string username, string pass)
        {
            using (var db = new MyDbContext())
            {
                var user = new User();
                return user.UserId = (from q in db.User where (q.Login_Name == username && q.Password == pass) select q.UserId).Single();
            }

        }

        public static List<User> GetallUser()
        {
            using (var db = new MyDbContext())
            {
                return db.User.ToList();


            }

        }
    }
}
