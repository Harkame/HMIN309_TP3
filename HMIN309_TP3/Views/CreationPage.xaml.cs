using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HMIN309_TP3.Models;

using HMIN309_TP3.Services;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationPage : ContentPage
    {
        public Event Event { get; set; }

        public CreationPage()
        {
            InitializeComponent();

            Event = new Event
            {
                Name = "Event name",
                Date = 0,
                Type = "Event type",
                Description = "Event description"
            };

            EventDatePicker = new DatePicker
            {
                MinimumDate = new DateTime(2018, 1, 1),
                MaximumDate = new DateTime(2019, 12, 31),
                Date = new DateTime(2018, 6, 21)
            };

            BindingContext = this;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            Event.Date = EventDatePicker.Date.Ticks;

            DatabaseHelper.InsertEvent(Event);

            DependencyService.Get<IMessage>().ShortAlert("Event created");
        }
    }
}