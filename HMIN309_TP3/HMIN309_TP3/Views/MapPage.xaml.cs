using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace HMIN309_TP3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        public MapPage()
        {
            InitializeComponent();

            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(35.71d, 139.81d), 12d);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(1000); // workaround for #30 [Android]Map.Pins.Add doesn't work when page OnAppearing

            var pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Tokyo SKYTREE",
                Address = "Sumida-ku, Tokyo, Japan",
                Position = new Position(35.71d, 139.81d)
            };
            map.Pins.Add(pin);

        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyDjd3wposlRaz0VoubNOIul-cI29qqR1hs" };
            IEnumerable<Address> addresses = geocoder.Geocode("1600 pennsylvania ave washington dc");
            Console.WriteLine("Formatted: " + addresses.First().FormattedAddress); //Formatted: 1600 Pennsylvania Ave SE, Washington, DC 20003, USA
            Console.WriteLine("Coordinates: " + addresses.First().Coordinates.Latitude + ", " + addresses.First().Coordinates.Longitude); //Coordinates: 38.8791981, -76.9818437
        }
    }
}