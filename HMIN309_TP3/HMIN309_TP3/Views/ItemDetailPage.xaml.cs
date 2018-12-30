using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HMIN309_TP3.Models;
using HMIN309_TP3.ViewModels;
using HMIN309_TP3.Services;
using Plugin.Media.Abstractions;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage, InterfaceEventOwner
    {
        private ItemDetailViewModel viewModel;

        public Event Event { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            Event = viewModel.Item;

            MediaFile photo = new MediaFile(Event.FilePath, () =>
            {
                return File.OpenRead(Event.FilePath);
            },
            null,
            Event.FilePath);

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            Event = new Event
            {
                Name = "",
                Description = ""
            };

            viewModel = new ItemDetailViewModel(Event);
            BindingContext = viewModel;
        }

        public async void DeleteEvent(object sender, EventArgs e)
        {
            DatabaseHelper.deleteEvent(Event);

            File.Delete(Event.FilePath);

            DependencyService.Get<IMessage>().ShortAlert("Event delete");

            await Navigation.PopAsync();
        }

        private async void Click_Geolocation(object sender, EventArgs e)
        {
            MapPage mappage = new MapPage(this);

            await Navigation.PushAsync(mappage);
        }
    }
}