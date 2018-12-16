using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HMIN309_TP3.Models;

using HMIN309_TP3.Services;
using Plugin.LocalNotifications;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationPage : ContentPage
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
                Description = ""
            };

            MinimumDate = DateTime.Now;
            Date = DateTime.Now;
            MaximumDate = DateTime.Now.AddYears(1);

            BindingContext = this;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            Event.Date = Date.Ticks + (long) NotificationTime.TotalSeconds;

            DatabaseHelper.InsertEvent(Event);

            CrossLocalNotifications.Current.Show(Event.Name, Event.Description, 101, new DateTime(Event.Date));

            DependencyService.Get<IMessage>().ShortAlert("Event created");
        }
    }
}