using A.pages.Forms;
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
using Windows.UI.Popups;
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
    public sealed partial class SettingsPage : Page
    {
        public UserVM user { get; set; }
        public Login log { get; set; }
        public Authentication auth { get; set; }
        public bool button;
        public SettingsPage()
        {
            this.InitializeComponent();
            this.user = new UserVM();
            this.auth = new Authentication();
            if (auth.isUserLogin())
            {
                noDon.Visibility = Visibility.Visible;
                update.Visibility = Visibility.Visible;
            }
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login.wanttodon == false)
            {
                using (var db = new MyDbContext())
                {
                    var entity = new User { UserId = Login.userId };
                    db.Attach(entity);
                    entity.wanttodonate = true;
                    db.SaveChanges();
                }
            }
            button = true;
            var dialog = new MessageDialog("You are now not visible as a Donor");
            await dialog.ShowAsync();
            Frame.Navigate(typeof(SettingsPage));
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserUpdate));
        }
    }
}
