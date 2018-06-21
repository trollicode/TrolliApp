using Com.OneSignal;
using OneSignalAPI.BeanClass;
using RealTrolli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageDetail : ContentPage
    {
        public MenuPageDetail()
        {
            InitializeComponent();
        }

        public void btn_text(Object sender, EventArgs e) {

            Navigation.PushAsync(new LatLongPushNotification());

        }
        bool notif = true;
        public void NotificationTest(Object sender, EventArgs e) {

            if(notif == true)
            {
                OneSignal.Current.SetSubscription(false);
                notif = false;
                DisplayAlert("Notification Msg", "Notification Off", "Ok");
            }
            else
            {

                OneSignal.Current.SetSubscription(true);
                notif = true;

                DisplayAlert("Notification Msg", "Notification On", "Ok");
            }
        }

        public void ToggledHandler(object sender, ToggledEventArgs e)
        {
            Dictionary<string, object> userData = ShareUserData.getUserData;
            bool isOnlineSeeker = e.Value;
            bool globalValue = Convert.ToBoolean(Application.Current.Properties["isOnlineJobSeeker"]);

            if (globalValue)
            {
                string fullName = Convert.ToString(userData["fullName"]);
                string simNumber = Convert.ToString(userData["simNumber"]);

                IsJobOnlineSeeker bean = new IsJobOnlineSeeker
                {
                    fullName = fullName,
                    simNumber = simNumber,
                    isJobSeeker = "false"
                };
                ApiCalling callApi = new ApiCalling();
                callApi.isJobOnlineSeeker(bean);
                Application.Current.Properties["isOnlineJobSeeker"] = false;
                globalValue = false;


                OneSignal.Current.SetSubscription(false);
                DisplayAlert("Notification Msg", "Notification Off", "Ok");
            }
            else
            {

                string fullName = Convert.ToString(userData["fullName"]);
                string simNumber = Convert.ToString(userData["simNumber"]);

                IsJobOnlineSeeker bean = new IsJobOnlineSeeker
                {
                    fullName = fullName,
                    simNumber = simNumber,
                    isJobSeeker = "true"
                };
                ApiCalling callApi = new ApiCalling();
                callApi.isJobOnlineSeeker(bean);
                Application.Current.Properties["isOnlineJobSeeker"] = true;
                globalValue = true;

                OneSignal.Current.SetSubscription(true);
                DisplayAlert("Notification Msg", "Notification On", "Ok");

            }

        }
    }
}