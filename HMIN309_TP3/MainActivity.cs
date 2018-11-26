using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace HMIN309_TP3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
            HomeFragment homeFragment = new HomeFragment();

            // The fragment will have the ID of Resource.Id.fragment_container.
            fragmentTx.Replace(Resource.Id.fragment_container, homeFragment);

            // Commit the transaction.
            fragmentTx.Commit();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);

            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();

            Fragment fragment;

            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    fragment = new HomeFragment();

                    fragmentTx.Replace(Resource.Id.fragment_container, fragment);

                    fragmentTx.Commit();
                    return true;
                case Resource.Id.navigation_event_creation:
                    fragment = new EventCreationFragment();

                    fragmentTx.Replace(Resource.Id.fragment_container, fragment);

                    fragmentTx.Commit();
                    return true;
            }

            return false;
        }
    }
}

