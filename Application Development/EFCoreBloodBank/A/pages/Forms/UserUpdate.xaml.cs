using A.ViewModel;
using EFCoreBloodBank;
using EFCoreBloodBank.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace A.pages.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserUpdate : Page
    {
        public UserVM user { get; set; }
        public Login login { get; set; }
        public UserUpdate()
        {
            this.InitializeComponent();
            this.user = new UserVM();
            user.RetrieveById(Login.userId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MyDbContext())
            {
                var entity = new User {UserId=Login.userId};
                db.User.Attach(entity);
                entity.Telephone = tel.Text;
                entity.Address = address.Text;
                entity.Email_address = email.Text;
                db.SaveChanges();
            }

            Frame.Navigate(typeof(UserUpdate));

        }
    }
}
