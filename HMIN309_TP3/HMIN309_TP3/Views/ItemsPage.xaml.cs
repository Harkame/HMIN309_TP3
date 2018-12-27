using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HMIN309_TP3.Models;
using HMIN309_TP3.ViewModels;
using static HMIN309_TP3.ViewModels.ItemsViewModel;

namespace HMIN309_TP3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel itemsViewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = itemsViewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Event;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            itemsViewModel.LoadItemsCommand.Execute(null);

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            itemsViewModel.LoadItemsCommand.Execute(null);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsListView.BeginRefresh();

            itemsViewModel.MyCommandd = new MyCommand(e.NewTextValue, itemsViewModel.Items);
            itemsViewModel.MyCommandd.Execute(null);

            ItemsListView.EndRefresh();
        }
    }
}