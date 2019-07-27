using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class DonorsNearMe : Page
    {
        public DonorsNearMe()
        {
            this.InitializeComponent();
        }

 

        private async void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            if (MyMap.Is3DSupported)
            {
                MyMap.Style = MapStyle.Aerial3DWithRoads;
                MyMap.StyleSheet = MapStyleSheet.RoadDark();
              

                BasicGeoposition geoPosition = new BasicGeoposition();
                geoPosition.Latitude = 41.790366;
                geoPosition.Longitude = -6.760116;
               
               Geopoint myPoint = new Geopoint(geoPosition);         
                MyMap.Center = myPoint;
                MyMap.ZoomLevel = 10;
                MapScene hwScene = MapScene.CreateFromLocationAndRadius(myPoint, 80, 0, 60);             
                await MyMap.TrySetSceneAsync(hwScene, MapAnimationKind.Bow);
                MapScene mapScene = MapScene.CreateFromLocationAndRadius(new Geopoint(geoPosition), 500, 150, 70);
                await MyMap.TrySetSceneAsync(mapScene);
            }
        }
    }
}
