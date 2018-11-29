using Android.Widget;
using System.ComponentModel;

using HMIN309_TP3.Models;
using Android.Content;
using Android.Views;
using Android.App;

namespace HMIN309_TP3.Adapters
{
    public class EventAdapter : ArrayAdapter<Event>
    {
        private TextView itemView;
        private Event[] items;
        private Activity context;

        public TextView ItemView
        {
            get
            {
                return ItemView;
            }

            set
            {
                itemView = value;
            }
        }

        public EventAdapter(Context context, int textViewResourceId, Event[] objects) : base(context, textViewResourceId, objects)
        {
            this.context = (Activity) context;

            items = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Event item = items[position];

            var view = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.event_row, parent, false)) as LinearLayout;

            var eventRowName = view.FindViewById(Resource.Id.event_row_name) as TextView;
            var eventRowDate = view.FindViewById(Resource.Id.event_row_date) as TextView;


            eventRowName.SetText(item.Name, TextView.BufferType.Normal);
            eventRowDate.SetText(item.Description, TextView.BufferType.Normal);

            return view;
        }
    }
}