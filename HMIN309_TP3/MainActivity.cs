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

            FragmentTransaction fragmentTransaction = this.FragmentManager.BeginTransaction();

            HomeFragment homeFragment = new HomeFragment();

            fragmentTransaction.Replace(Resource.Id.fragment_container, homeFragment);

            fragmentTransaction.Commit();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);

            navigation.SetOnNavigationItemSelectedListener(this);

            DatabaseHelper.Initialize();
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            FragmentTransaction fragmentTransaction = this.FragmentManager.BeginTransaction();

            Fragment fragment;

            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    fragment = new HomeFragment();

                    fragmentTransaction.Replace(Resource.Id.fragment_container, fragment);

                    fragmentTransaction.Commit();
                    return true;
                case Resource.Id.navigation_event_creation:
                    fragment = new EventCreationFragment();

                    fragmentTransaction.Replace(Resource.Id.fragment_container, fragment);

                    fragmentTransaction.Commit();
                    return true;
            }

            return false;
        }
    }
}

