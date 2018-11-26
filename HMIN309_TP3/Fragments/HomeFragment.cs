using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using HMIN309_TP3.Models;

namespace HMIN309_TP3
{
    public class HomeFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_home, container, false);

            return view;
        }

        public virtual void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Event[] events = DatabaseHelper.getAllEvents();

            string[] countries = { };

            ListView eventsList = view.FindViewById<ListView>(Resource.Id.list_events);

            ArrayAdapter adapter = new ArrayAdapter<string>(this.Context, Resource.Layout.list_item, countries);

            eventsList.Adapter = adapter;
        }
    }
}

