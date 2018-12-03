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
        public DateTime Date { get; set; }

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

            BindingContext = this;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            DatabaseHelper.InsertEvent(Event);

            DependencyService.Get<IMessage>().ShortAlert("Event created");
        }
    }
}