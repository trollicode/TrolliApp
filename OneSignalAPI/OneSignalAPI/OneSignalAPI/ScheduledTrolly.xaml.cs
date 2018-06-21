using Newtonsoft.Json;
using OneSignalAPI.BeanClass;
using RealTrolli;
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
	public partial class ScheduledTrolly : ContentPage
	{
		public ScheduledTrolly ()
		{
			InitializeComponent ();
            
            currentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            currentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public string getItemsInJson()
        {
            ObservableCollection<ListProduct> listProducts = ShareUserData.addProduct;
            string output = "";
            foreach (ListProduct list in listProducts)
            {
                output += JsonConvert.SerializeObject(list) + ",";
            }

            return output;
        }

        public void SaveTrolly(Object sender, EventArgs e)
        {
            ApiCalling apiCall = new ApiCalling();
            Dictionary<string, object> userData = ShareUserData.getUserData;
            string deliveryDateTime = "";
            if(datePicker.IsVisible == true && timePicker.IsVisible == true)
            {
                DateTime dateOnly = datePicker.Date;
                //DateTime dateOnly = timePicker.Time;
                deliveryDateTime = dateOnly.ToString("dd/MM/yyyy") + " " + timePicker.Time.ToString();
            }
            else
            {
                deliveryDateTime = currentDate.Text + " " + currentTime.Text;
            }
            TrollyCreation trolly = new TrollyCreation
            {
                createdDate = DateTime.Now.ToString("dd/MM/yyyy"),
                lastModifiedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                trollyTitle = "My Trolly",
                trollyDetail = getItemsInJson(),
                assigneeId = "1234",
                clientId = Convert.ToString(userData["simNumber"]),
                status = "pending",
                isScheduledDelivery = "true",
                deliveryDateTime = deliveryDateTime

            };

            apiCall.trollyCreation(trolly);
            Navigation.PushAsync(new PaymentCardInfo());
        }


        public void toggled_event(Object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                datePicker.IsVisible = true;
                currentDate.IsVisible = false;

                timePicker.IsVisible = true;
                currentTime.IsVisible = false;
            }
            else
            {
                datePicker.IsVisible = false;
                currentDate.IsVisible = true;

                timePicker.IsVisible = false;
                currentTime.IsVisible = true;
            }
        }
    }
}