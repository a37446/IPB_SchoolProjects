using A.ViewModel;
using BloodBank.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
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
    public sealed partial class AddNews : Page
    {
        public NewsVM newsVm { get; set; }
        
        public AddNews()
        {
            this.InitializeComponent();
            this.newsVm = new NewsVM();
        }

        private async void Taskfail()
        {
            ContentDialog Taskcomplete = new ContentDialog()
            {
                Title = "Cannot add the News",
                Content = "Check if Title/News Details are not empty",
                CloseButtonText = "Ok"
            };

            await Taskcomplete.ShowAsync();
        }

        private void Addnews_Button(object sender, RoutedEventArgs e)
        {
           var news = new News {Title=title.Text,details=description.Text };
           if (title.Text == "" || description.Text == "")
            {
                Taskfail();
            }
            else
            {
                this.newsVm.AddNews(news);
                Frame.Navigate(typeof(HomePage));
            }
        }

        private async Task<string> ToBase64(StorageFile bitmap)
        {
            var stream = await bitmap.OpenAsync(Windows.Storage.FileAccessMode.Read);
            var decoder = await BitmapDecoder.CreateAsync(stream);
            var pixels = await decoder.GetPixelDataAsync();
            var bytes = pixels.DetachPixelData();
            return await ToBase64(bytes, (uint)decoder.PixelWidth, (uint)decoder.PixelHeight, decoder.DpiX, decoder.DpiY);
        }
        
        private async Task<string> ToBase64(byte[] image, uint height, uint width, double dpiX=96, double dpiY=96)
        {
            var encoded = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8,BitmapAlphaMode.Straight, height,width,dpiX,dpiY,image);
            await encoder.FlushAsync();
            encoded.Seek(0);

            var bytes = new byte[encoded.Size];
            await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);

            return Convert.ToBase64String(bytes);

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.SettingsIdentifier = "picker1";
            filePicker.CommitButtonText = "Open File to Process";

            var files = await filePicker.PickMultipleFilesAsync();

            if (files.Count > 0)
            {
                // encode the storage file to base64
                var base64 = await ToBase64(files[0]);
                // asynchronously save base64 string to database
                // ...
                
                // decode the base64 and set the image source
                //LogoImage.Source = await Encoding.FromBase64(base64);
            }

        }
    }
}
