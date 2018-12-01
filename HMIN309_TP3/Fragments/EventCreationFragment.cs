using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using HMIN309_TP3.Models;

namespace HMIN309_TP3
{
    public class EventCreationFragment : Fragment
    {
        private DatabaseHelper databaseHelper;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_event_creation, container, false);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            databaseHelper = new DatabaseHelper();


            Button dateButton = view.FindViewById<Button>(Resource.Id.eventCreationDate);

            dateButton.Click += delegate
            {
                DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
                {
                    dateButton.Text = time.ToLongDateString();
                });

                frag.Show(FragmentManager, DatePickerFragment.TAG);
            };

            Button creationButton = view.FindViewById<Button>(Resource.Id.eventCreationValidate);


            creationButton.Click += delegate
            {
                string toastMessage = "";
                bool validEvent = true;

                TextView eventNameTextView = view.FindViewById<TextView>(Resource.Id.eventCreationName);

                if (eventNameTextView.Text.Length == 0)
                {
                    toastMessage = "Invalid event name";

                    validEvent = false;
                }

                DatePicker eventDatePicker = view.FindViewById<DatePicker>(Resource.Id.eventCreationDate);

                TextView eventDescriptionTextView = view.FindViewById<TextView>(Resource.Id.eventCreationDescription);

                if (validEvent == true)
                {
                    Event newEvent = new Event(eventNameTextView.Text, 0, "", eventDescriptionTextView.Text);

                    databaseHelper.InsertEvent(newEvent);

                    toastMessage = "Event created";
                }

                Android.Widget.Toast.MakeText(this.Context, toastMessage, ToastLength.Long).Show();
            };
        }
    }
}

