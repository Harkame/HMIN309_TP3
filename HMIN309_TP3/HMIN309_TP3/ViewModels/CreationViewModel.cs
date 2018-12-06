using HMIN309_TP3.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace HMIN309_TP3.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AboutViewModel()
        {
            Title = "Creation";
        }
    }
}