
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using HMIN309_TP3.Models;

[assembly: Xamarin.Forms.Dependency(typeof(HMIN309_TP3.Droid.NotificationHelper))]
namespace HMIN309_TP3.Droid
{
    public static class NotificationHelper
    {
        public static JniHandleOwnership CHANNEL_ID { get; private set; }

        public static void CreateLocaNotification(long eventTime)
        {
            //TODO
        }

    }
}