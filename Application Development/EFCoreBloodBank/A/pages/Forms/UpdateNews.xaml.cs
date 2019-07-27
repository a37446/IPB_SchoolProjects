using A.ViewModel;
using BloodBank.Classes;
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
    public sealed partial class UpdateNews : Page
    {

        public NewsVM news { get; set; }

        public static int getId { get; set; }

        public UpdateNews()
        {
            this.InitializeComponent();
            this.news = new NewsVM();
            int id = getId;

            news.RetrievebyId(id);
        }

        
        private void naya(object sender, RoutedEventArgs e)
        {
            using(var db=new MyDbContext())
            {
                var entity = new News { NewsId = getId };
                db.News.Attach(entity);
                entity.Title = title.Text;
                entity.details = desc.Text;
                db.SaveChanges();
            }
            
            Frame.Navigate(typeof(AllNewsList));
           
        }
    }
}
