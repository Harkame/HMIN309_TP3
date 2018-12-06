using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using HMIN309_TP3.Models;

namespace HMIN309_TP3.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Home";
            Items = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            Items.Clear();

            var items = await Task.FromResult(DatabaseHelper.GetAllEvents());

            foreach (var item in items)
            {
                item.DateText = new DateTime(item.Date).ToLongDateString();
                Items.Add(item);
            }
        }
    }
}