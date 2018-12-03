using HMIN309_TP3.Models;

namespace HMIN309_TP3.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Event Item { get; set; }
        public ItemDetailViewModel(Event item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
