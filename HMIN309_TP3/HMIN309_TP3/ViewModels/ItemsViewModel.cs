using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using HMIN309_TP3.Models;
using System.Windows.Input;

namespace HMIN309_TP3.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command LoadItemsByNameCommand { get; set; }
        public ICommand MyCommandd { get; set; }

        public ItemsViewModel()
        {
            Title = "Home";
            Items = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await LoadItems());
        }

        public async Task LoadItems()
        {
            Items.Clear();

            var events = await Task.FromResult(DatabaseHelper.GetAllEvents());

            foreach (var item in events)
                Items.Add(item);
        }

        public class MyCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private string EventName { get; set; }
            public ObservableCollection<Event> Items { get; set; }

            public MyCommand(string eventName, ObservableCollection<Event> items)
            {
                EventName = eventName;
                Items = items;
            }

            public bool CanExecute(object parameter)
            {
                throw new NotImplementedException();
            }

            public async void Execute(object parameter)
            {
                Items.Clear();

                var items = await Task.FromResult(DatabaseHelper.GetAllEventsByNameOrDate(EventName));

                foreach (var item in items)
                {
                    item.DateText = new DateTime(item.Date).ToLongDateString();
                    Items.Add(item);
                }
            }
        }
    }
}