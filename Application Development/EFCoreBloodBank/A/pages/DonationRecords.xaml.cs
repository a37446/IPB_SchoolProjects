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
    public sealed partial class DonationRecords : Page
    {
        private Authentication auth = new Authentication();
        public UserVM userVM { get; set; }
        public DonationVM donationVM { get; set; }
        public User_DonationVM Ud { get; set; }

        public DonationRecords()
        {
            this.InitializeComponent();
            this.userVM = new UserVM();
            this.donationVM = new DonationVM();
            this.donationVM.Retrieve();
            this.Ud = new User_DonationVM();
            Ud.UserDonation();

            Authentication auth = new Authentication();
            if (auth.isUserLogin())
            {
                record.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Record));
        }
    }
}
