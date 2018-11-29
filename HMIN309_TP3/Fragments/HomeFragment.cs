using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using HMIN309_TP3.Models;

using HMIN309_TP3.Adapters;

namespace HMIN309_TP3
{
    public class HomeFragment : Fragment
    {
        private DatabaseHelper databaseHelper;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_home, container, false);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            databaseHelper = new DatabaseHelper();

            Event[] events = databaseHelper.getAllEvents();

            ListView eventsList = view.FindViewById<ListView>(Resource.Id.list_events);

            EventAdapter adapter = new EventAdapter(this.Context, Resource.Layout.event_row, events);

            eventsList.Adapter = adapter;
        }
    }
}

