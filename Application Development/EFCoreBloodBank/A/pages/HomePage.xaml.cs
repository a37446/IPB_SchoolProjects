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
using A.ViewModel;
using BloodBank.Classes;
using A.pages.Forms;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace A.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        public UserVM userVM { get; set; }
        //public Login login { get; set; }
        public login_Controll logincontroll { get; set; }
        private Authentication auth = new Authentication();
        public NewsVM news { get; set; }
        public bool islogout;
      
        public static bool isAd=false;

        public HomePage()
        {

            this.InitializeComponent();
            this.userVM = new UserVM();
            login_Controll logincontroll = new login_Controll();
            this.news = new NewsVM();
            news.RetrieveAll();
           // Login login = new Login();
            Authentication auth = new Authentication();
            if (auth.isUserLogin())
            {
                loginU.Visibility = Visibility.Collapsed;
                logoutm.Visibility = Visibility.Visible;
            }
            if (islogout)
            {
                logoutm.Visibility = Visibility.Collapsed;
                loginU.Visibility = Visibility.Visible;
            }
            if (isAd)
            {
                Addnews.Visibility = Visibility.Visible;
               newlist.Visibility = Visibility.Visible;
            }
           
        }




        private void Button_Login(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
           

        }

        private void Addnews_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNews));

        }

        private void ListNews_Button(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AllNewsList));
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            Authentication auth = new Authentication();
            auth.logout();
            Frame.Navigate(typeof(HomePage));
            islogout = true;
            Frame.Navigate(typeof(HomePage));

        }

    }
}