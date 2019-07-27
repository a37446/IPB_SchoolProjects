using A.ViewModel;
using EFCoreBloodBank.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace A.pages.Doners
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class O_ : Page
    {
        public UserVM user { get; set; }
        public O_()
        {
            this.InitializeComponent();
            this.user = new UserVM();
            this.user.Retrievebybloodtype("O+");
        }

        private async  void Button_Click(object sender, RoutedEventArgs e)
        {
            string A = box.Text;
            if (A == "A+")
            {
                Frame.Navigate(typeof(A_));
            }
            else if (A == "B+")
            {
                Frame.Navigate(typeof(B_));

            }
            else if (A == "AB+")
            {
                Frame.Navigate(typeof(AB_));
            }
            else if (A == "O+")
            {
                Frame.Navigate(typeof(O_));
            }
            else if (A == "A-")
            {
                Frame.Navigate(typeof(Aneg));
            }
            else if (A == "B-")
            {
                Frame.Navigate(typeof(Bneg));

            }
            else if (A == "AB-")
            {
                Frame.Navigate(typeof(ABneg));
            }
            else if (A == "O-")
            {
                Frame.Navigate(typeof(Oneg));
            }
            else
            {
                var dialog = new MessageDialog("Wrong Bloodtype!");
                await dialog.ShowAsync();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Receiver = (sender as Button).DataContext as User;
            string email = Receiver.Email_address;

            user.SendEmail(email);

        }
    }
}
