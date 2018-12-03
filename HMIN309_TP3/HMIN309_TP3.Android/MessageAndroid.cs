using Android.App;using Android.Widget;
using HMIN309_TP3.Services;

[assembly: Xamarin.Forms.Dependency(typeof(HMIN309_TP3.Droid.MessageAndroid))]
namespace HMIN309_TP3.Droid
{
    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
        
}