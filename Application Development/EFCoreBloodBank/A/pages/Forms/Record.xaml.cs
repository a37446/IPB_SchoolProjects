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

namespace A.pages.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Record : Page
    {
        public DonationVM user_DonationVM { get; set; }
        public Login login { get; set; }
        public static int Donorid;

        public Record()
        {
            this.InitializeComponent();
            this.user_DonationVM = new DonationVM();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var user_don = new Donation { Addresses = donationlocation.Text,
                Medical_Incharge = towhom.Text, Dates = date.Date.LocalDateTime,
                Descriptions=donationdescription.Text, UserID=Login.userId
            };
            if (donationdescription.Text == "" || donationlocation.Text == "" || towhom.Text == "")
            {
                var dialo = new MessageDialog("Action Failed !");
                await dialo.ShowAsync();
            }
            else
            {
                this.user_DonationVM.AddDonation(user_don);
                Donorid = Login.userId;
                var dialog = new MessageDialog("Sucessfully recorded.Thankyou for letting us know!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(DonationRecords));
            }
        }
    }
}
