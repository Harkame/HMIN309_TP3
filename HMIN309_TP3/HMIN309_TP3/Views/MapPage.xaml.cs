using HMIN309_TP3.Models;
using HMIN309_TP3.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        Pin pin;
        private InterfaceEventOwner InterfaceEventOwner { get; set; }

        public MapPage(InterfaceEventOwner interfaceEventOwner)
        {
            InitializeComponent();

            InterfaceEventOwner = interfaceEventOwner;
            
            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(InterfaceEventOwner.Event.Latitude, InterfaceEventOwner.Event.Longitude), 12d);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(1000);

            string showedAddress = "";

            if (InterfaceEventOwner.Event.Address.Equals(""))
                showedAddress = "Current";
            else
                showedAddress = InterfaceEventOwner.Event.Address;

            pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Event",
                Address = showedAddress,
                Position = new Position(InterfaceEventOwner.Event.Latitude, InterfaceEventOwner.Event.Longitude)
            };
            map.Pins.Add(pin);

        }


        private async void ResolveAddress(string address)
        {
            string url = "https://maps.googleapis.com/maps/api/geocode/json?" + "address=" + address + "&key=" + "AIzaSyBQ9s-I2YGlocgEKe0fVUid6mUqacCaqbE";

            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(url);

            JObject json = JObject.Parse(content);

            JObject results = (JObject)json.GetValue("results").First;

            JContainer locationContainer = (JContainer)results.GetValue("geometry").First.Next;

            JObject location = (JObject)locationContainer.First;

            double latitude = Double.Parse(location.GetValue("lat").ToString());
            double longitude = Double.Parse(location.GetValue("lng").ToString());

            InterfaceEventOwner.Event.Latitude = latitude;
            InterfaceEventOwner.Event.Longitude = longitude;
            InterfaceEventOwner.Event.Address = address;

            map.Pins.Remove(pin);

            pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Event",
                Address = InterfaceEventOwner.Event.Address,
                Position = new Position(latitude, longitude)
            };

            map.Pins.Add(pin);

            await map.MoveCamera(CameraUpdateFactory.NewPositionZoom(new Position(InterfaceEventOwner.Event.Latitude, InterfaceEventOwner.Event.Longitude), 12d));
        }

        private async void Click_Geolocation(object sender, EventArgs e)
        {
            //ResolveAddress(SearchBar.Text);

            await Navigation.PopAsync();
        }

        private void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            ResolveAddress(SearchBar.Text);
        }
    }
}