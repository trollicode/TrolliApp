using Newtonsoft.Json;
using OneSignalAPI;
using OneSignalAPI.BeanClass;
using Plugin.DeviceInfo;
using RealTrolli;
using RealTrolli.BeanClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealTrolli
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeTrolliPage : ContentPage
    {
        public WelcomeTrolliPage()
        {
            InitializeComponent();
            //initial progress is 20%
           
            CheckDeviceId();
        }

        private static string url = "https://trolli-194513.appspot.com/registration";
        static HttpClient _client = new HttpClient();
        static Dictionary<string, object> values = null;

        public async void CheckDeviceId()
        {
           await progressBar.ProgressTo(1, 5000, Easing.CubicIn);
            // animate the progression to 80%, in 250ms
            //await progressBar.ProgressTo
            string deviceIdJson = "";

            var deviceId = CrossDeviceInfo.Current.Id;
            string content = await _client.GetStringAsync(url);
            if (Application.Current.Properties.ContainsKey("phoneNumber"))
            {

                List<Dictionary<string, object>> posts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);

                foreach (Dictionary<string, object> i in posts)
                {

                    Dictionary<string, object> post = JsonConvert.DeserializeObject<Dictionary<string, object>>(Convert.ToString(i["properties"]));
                    deviceIdJson = Convert.ToString(post["deviceId"]);
                    if (deviceIdJson == deviceId)
                    {
                        
                        Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(Convert.ToString(i["properties"]));
                        ShareUserData.getUserData = values;

                        await Navigation.PushAsync(new MenuPage());
                    }
                }
            }
            else
            {
                await Navigation.PushAsync(new Registrations());
            }


        }

      

    }
}