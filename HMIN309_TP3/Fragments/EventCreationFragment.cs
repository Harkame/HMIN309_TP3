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
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_event_creation, container, false);

            return view;
        }

        public virtual void OnViewCreated(View view, Bundle savedInstanceState)
        {
            Button creationButton = view.FindViewById<Button>(Resource.Id.eventCreationValidate);

            creationButton.Click += (sender, e) => {
                string toastText = "";
                bool validEvent = true;

                TextView eventNameTextView = view.FindViewById<TextView>(Resource.Id.eventCreationName);

                if (eventNameTextView.Text.Length == 0)
                    toastText = "Invalid event name";
                
                TextView eventDescriptionTextView = view.FindViewById<TextView>(Resource.Id.eventCreationDescription);

                if (validEvent == true)
                {
                    Event newEvent = new Event(eventNameTextView.Text, "", eventDescriptionTextView.Text);

                    DatabaseHelper.InsertEvent(newEvent);

                    toastText = "Event created";
                }

                Toast toast = new Toast(this.Context);
                toast.SetText(toastText);
                toast.Show();
            };
        }
    }
}

