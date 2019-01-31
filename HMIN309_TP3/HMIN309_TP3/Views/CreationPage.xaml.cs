using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HMIN309_TP3.Models;
using HMIN309_TP3.Services;
using Plugin.LocalNotifications;
using Plugin.Media.Abstractions;
using Plugin.Geolocator;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using System.Collections.Generic;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationPage : ContentPage, InterfaceEventOwner
    {
        public Event Event { get; set; }
        public DateTime MinimumDate { get; set; }
        public DateTime Date { get; set; }
        public DateTime MaximumDate { get; set; }
        public TimeSpan NotificationTime { get; set; }

        public CreationPage()
        {
            InitializeComponent();

            Event = new Event
            {
                Name = "",
                Date = 0,
                Type = "",
                Description = "",
                Address = "",
                Latitude = 0.0,
                Longitude = 0.0
            };



            MinimumDate = DateTime.Now;
            Date = DateTime.Now;
            MaximumDate = DateTime.Now.AddYears(1);

            BindingContext = this;

            getCurrentPosition();

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    
                }
                else
                {
                    Event.Type = picker.ItemsSource[picker.SelectedIndex].ToString();
                }
            };

            CameraButton.Clicked += CameraButton_Clicked;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            if(Event.Name.Length == 0)
            {
                DependencyService.Get<IMessage>().ShortAlert("Invalid event name");
                return;
            }

            Event.Date = Date.Ticks + (long) NotificationTime.TotalSeconds;

            Event.DateText = new DateTime(Event.Date).ToLongDateString();

            DatabaseHelper.InsertEvent(Event);

            CrossLocalNotifications.Current.Show(Event.Name, Event.Description, 101, new DateTime(Event.Date));

            DependencyService.Get<IMessage>().ShortAlert("Event created");
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            MediaFile photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                Event.FilePath = photo.AlbumPath;
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private async void Click_Geolocation(object sender, EventArgs e)
        {
            MapPage mappage = new MapPage(this);

            await Navigation.PushAsync(mappage);
        }

        private async void getCurrentPosition()
        {
            var locator = CrossGeolocator.Current;

            Position currentPosition = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            Event.Latitude = currentPosition.Latitude;
            Event.Longitude = currentPosition.Longitude;
        }
    }
}