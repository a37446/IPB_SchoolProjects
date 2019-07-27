using EFCoreBloodBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A.pages;
using EFCoreBloodBank.Classes;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace A.ViewModel
{
    public class login_Controll
    {
        public Login login { get; set; }
        public User user { get; set; }
        static bool flag = false;
        readonly MyDbContext _dbContext = new MyDbContext();

        public bool UserExists(string userName, string password)
        {
            using (var db = new MyDbContext())
            {
                return db.User.Any(x => x.Login_Name.Equals(userName, StringComparison.InvariantCultureIgnoreCase)
                                      && x.Password.Equals(password, StringComparison.InvariantCultureIgnoreCase));
            }
        }  
       
        
        

       public bool CheckAdmin(string username,string pass)
        {
           
            using (var db=new MyDbContext()) {
                var user = new User();
                return user.isAdmin=(from q in db.User where(q.Login_Name==username && q.Password==pass) select q.isAdmin).Single();
                /*if ((username == "Admin" || username == "admin") && pass == "admin") return true;
                else return false;
             (from q in db.Shows where (q.Id == 1) select q.Donations).Single();   
             */
            }
           
        }
      
        public bool uservalidation(string login,string pass)
        {
            UserVM user = new UserVM();

            ObservableCollection<User> check = user.RetrievebyUsernameAndPassword(login, pass);

            Authentication validation = new Authentication();
            bool userLogin = validation.login(check);
            if (userLogin) return true;
            else return false;
        }
      
    

    }
}
