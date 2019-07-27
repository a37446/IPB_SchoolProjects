using A.pages.Forms;
using A.ViewModel;
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

namespace A.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public UserVM userVM { get; set; }
        public HomePage home { get; set; }
        public login_Controll logincontroll{get;set;}  
        public bool isLogged =false;
        public Search search { get; set; }
        public static int userId;
        public static bool wanttodon;

        //public bool isAdmin = false;
        public static bool flaG = false;
        
        
       

        public Login()
        {
            this.InitializeComponent();
            this.userVM = new UserVM();
            this.logincontroll = new login_Controll();
            this.home = new HomePage();
        }
        public void  chck()
        {
           
        }
        private async void DisplayLoginSuccess()
        {
            ContentDialog Taskcomplete = new ContentDialog()
            {
                Title="Login Success!",
                Content = "LogIn Successful!!",
                CloseButtonText = "Ok"
            };

            await Taskcomplete.ShowAsync();
        }
        private async void DisplayNotRegistered()
        {
            ContentDialog Taskcomplete = new ContentDialog()
            {
                Title = "Wrong Password/LoginName!",
                CloseButtonText = "Ok"
            };

            await Taskcomplete.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            isLogged = logincontroll.uservalidation(Login_name.Text, password.Password.ToString());
            if (isLogged)
            {
              
                DisplayLoginSuccess();
                userId= userVM.RetrieveUserID(Login_name.Text, password.Password.ToString());
                wanttodon = userVM.Checkwantstodonate(Login_name.Text, password.Password.ToString());
                if (logincontroll.CheckAdmin(Login_name.Text, password.Password.ToString()))
                { HomePage.isAd = true; }
                Frame.Navigate(typeof(HomePage));
            }
            else
            {
                DisplayNotRegistered();
            }
        }

        public string loginname() { return Login_name.Text; }
        public string passreturn() { return password.Password.ToString(); }
        
        public static bool IsAdmin()
        {
            return flaG;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(Register));
        }
    }
}
