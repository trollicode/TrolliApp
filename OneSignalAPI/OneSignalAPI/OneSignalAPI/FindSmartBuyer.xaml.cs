using Newtonsoft.Json;
using OneSignalAPI.BeanClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FindSmartBuyer : ContentPage
	{
		public FindSmartBuyer ()
		{
			InitializeComponent ();
            findSmartBuyer();
		}
        private static string url = "https://trolli-194513.appspot.com/isOnlineJobSeeker";
        static HttpClient _client = new HttpClient();
      private List<IsJobOnlineSeeker> smartBuyer = new List<IsJobOnlineSeeker>();
        public async void findSmartBuyer() {
            string content = await _client.GetStringAsync(url);
            List<Dictionary<string, object>> posts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);
            bool isJobSeekerCheck;
            foreach (Dictionary<string, object> i in posts)
            {
                Dictionary<string, object> post = JsonConvert.DeserializeObject<Dictionary<string, object>>(Convert.ToString(i["properties"]));
                isJobSeekerCheck = Convert.ToBoolean(post["isJobSeeker"]);
                if(isJobSeekerCheck == true)
                {
                    bool isJob = Convert.ToBoolean(post["isJobSeeker"]);
                    string name = Convert.ToString(post["fullName"]);
                    string sim = Convert.ToString(post["simNumber"]);
                    IsJobOnlineSeeker ob = new IsJobOnlineSeeker
                    {
                        isJobSeeker = Convert.ToString(isJob),
                        fullName = name,
                        simNumber = sim
                    };
                    smartBuyer.Add(ob);
                }
            }
       //     listView.ItemsSource = null;
        //    listView.ItemsSource = smartBuyer;
            }

        public void findSmart(object sender, EventArgs e)
        {
           
            listView.ItemsSource = null;
            listView.ItemsSource = smartBuyer;

        }
    }
}