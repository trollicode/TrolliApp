using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestWebView : ContentPage
	{
		public TestWebView ()
		{
			InitializeComponent ();
            Application.Current.Properties["isOnlineJobSeeker"] = false;
            switchToggled.IsToggled = true;
        }

        public void DeleteEvent(Object sender, SelectedItemChangedEventArgs e)
        {
//            var content = (sender as Button).CommandParameter as string;

            var selectedLocation = (sender as Button).CommandParameter.ToString();

            DisplayAlert("", selectedLocation, "OK");
            //var content = (sender as MenuItem).CommandParameter as string;
        }

        ObservableCollection<string> data = new ObservableCollection<string>();
        public void ListOfStore()
        {
            data.Add("Barneys New York");
            data.Add("Bealls (Florida)");
            data.Add("Belk");
            data.Add("The Bon-Ton");
            data.Add("Boscov's");
            data.Add("Dillard's");
            data.Add("J. C. Penney");
            data.Add("Central Park Mall");
            data.Add("Mid City Centre");

        }

        public void ToggledHandler(object sender, ToggledEventArgs e)
        {
            bool globalValue = Convert.ToBoolean(Application.Current.Properties["isOnlineJobSeeker"]);
            
            if (globalValue)
            {

                Application.Current.Properties["isOnlineJobSeeker"] = false;
                globalValue = false;
                
            }
            else
            {

                Application.Current.Properties["isOnlineJobSeeker"] = true;
                globalValue = true;
                
            }

            DisplayAlert("", ""+globalValue, "ok");
        }

    }
}
