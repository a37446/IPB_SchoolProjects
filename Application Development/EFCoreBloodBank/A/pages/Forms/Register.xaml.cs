using A.ViewModel;
using EFCoreBloodBank;
using EFCoreBloodBank.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class Register : Page
    {
        public UserVM UserVM { get; set; }
        public Register()
        {
            this.InitializeComponent();
            this.UserVM = new UserVM();
        }

        private async void DisplayTaskfail()
        {
            ContentDialog Taskcomplete = new ContentDialog()
            {
                Title = "Registration Failed",
                Content = "Check if all the requirements are filled",
                CloseButtonText = "Ok"
            };

            await Taskcomplete.ShowAsync();
        }
        private async void DisplayBloodTypeMistake()
        {
            ContentDialog Taskcomplete = new ContentDialog()
            {
                Title = "Wrong BloodType",
                Content = "Pelase insert correct BloodType",
                CloseButtonText = "Ok"
            };

            await Taskcomplete.ShowAsync();
        }
        private async void DisplayTaskComplete()
        {
            ContentDialog Taskcomplete = new ContentDialog()
            {
                Title = "Registration Sucessful",
                Content = "You can now login :)",
                CloseButtonText = "Ok",

            };


            await Taskcomplete.ShowAsync();
            this.Frame.Navigate(typeof(Login));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new User { Name = Name.Text, Email_address = email.Text, Login_Name = loginname.Text, Password = password.Password, BloodType = bloodtype.Text, Address = address.Text, Telephone = Teleph.Text };

            if ((user.Name != null && user.Email_address != null && user.Password != null && !string.IsNullOrWhiteSpace(user.Login_Name))
                && (user.BloodType == "A+" || user.BloodType == "AB+" || user.BloodType == "A-" || user.BloodType == "B-"
               || user.BloodType == "AB-" || user.BloodType == "O+" || user.BloodType == "O-" || user.BloodType == "B+"))
            {
                this.UserVM.AddUser(user);
                DisplayTaskComplete();
            }
            else
            {
                DisplayTaskfail();

                /*else if ((user.BloodType!=null)&&
                    (user.BloodType != "A+" || user.BloodType != "AB+" || user.BloodType != "A-" || user.BloodType != "B-"
                || user.BloodType != "AB-" || user.BloodType != "O+" || user.BloodType != "O-" || user.BloodType != "B+"))
                {
                    DisplayBloodTypeMistake();
                }
               */
            }
        }

       
    }
  
}
