using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HMIN309_TP3.Models;
using HMIN309_TP3.ViewModels;
using HMIN309_TP3.Services;
using Plugin.Media.Abstractions;
using System.IO;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel viewModel;

        private Event item;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            item = viewModel.Item;

            MediaFile photo = new MediaFile(item.FilePath, () =>
            {
                return File.OpenRead(item.FilePath);
            },
            null,
            item.FilePath);

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
            
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            item = new Event
            {
                Name = "",
                Description = ""
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public async void DeleteEvent(object sender, EventArgs e)
        {
            DatabaseHelper.deleteEvent(item);

            File.Delete(item.FilePath);

            DependencyService.Get<IMessage>().ShortAlert("Event delete");

            await Navigation.PopAsync();
        }
    }
}