using Newtonsoft.Json;
using OneSignalAPI;
using OneSignalAPI.BeanClass;
using RealTrolli.ApiClass;
using RealTrolli.BeanClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealTrolli
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent ();
            loadProfile();

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

       

        string imageId = "";

        public void loadProfile() {



            Dictionary<string, object> userData = ShareUserData.getUserData;
            //  SignupBean bean2 = bal.getData();


            nameTxt.Text = Convert.ToString(userData["fullName"]);
                  emailTxt.Text = Convert.ToString(userData["email"]);
                  stateTxt.Text = Convert.ToString(userData["state"]);
                   subrubTxt.Text = Convert.ToString(userData["suburb"]);
                   postalTxt.Text = Convert.ToString(userData["postCode"]);
            imageId = Convert.ToString(userData["gdProfileImageId"]);
           // profileImage.Source = "https://drive.google.com/uc?export=view&id=" + imageId;
           
            if (imageId == "")
            {
                profileImage.Source = "logo2.png";
            }
            else
            {
                profileImage.Source = "https://drive.google.com/uc?export=view&id=" + imageId;

            }

    
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadProfile();
        }

        public void btn_editProfile(Object sender, EventArgs e) {

            Navigation.PushModalAsync(new ProfileUpdate());


        }


      
    }
}