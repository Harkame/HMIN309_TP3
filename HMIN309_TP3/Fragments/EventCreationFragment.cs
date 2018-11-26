using Android.App;
using Android.OS;
using Android.Views;

namespace HMIN309_TP3
{
    public class EventCreationFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_event_creation, container, false);

            return view;
        }
    }
}

