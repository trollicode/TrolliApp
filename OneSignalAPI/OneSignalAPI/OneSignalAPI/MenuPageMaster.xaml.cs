using OneSignalAPI.BeanClass;
using RealTrolli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : ContentPage
    {
        public ListView ListView;

        public MenuPageMaster()
        {
            InitializeComponent();
            //  btn.ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left,10);
          
            loadProfile();
            statesPicker.SelectedItem = "Use as Smart Buyer";
        }

        public void myTrollyEvent(object sender, EventArgs e) {

            Navigation.PushAsync(new CreateTrolli());
        }


        public void changeEvent(Object sender, EventArgs e) {
            string statesPickers = statesPicker.Items[statesPicker.SelectedIndex];
            string statess = statesPickers;

            if (statess == "Use as Client")
            {
                //   currentJob.IsEnabled = true;
                myJob.IsVisible = false;
                myTrolli.IsVisible = true;


            }
            else if (statess == "Use as Smart Buyer")
            {
                //   currentJob.IsEnabled = false;
                myJob.IsVisible = true;
                myTrolli.IsVisible = false;

            }



        }


        public void getChanges() {
            string statesPickers = statesPicker.Items[statesPicker.SelectedIndex];
            string statess = statesPickers;
            
            if (statess == "Use as Client")
            {
                
            }
            else if (statess == "Use as Smart Buyer") {

            } 

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadProfile();
        }

    /*    public void IsJobSeeker(Object sender, EventArgs e) {

            if (nameJobRole.Text == "Use as Smart Buyer")
            {
                nameJobRole.Text = "Use as Client";
            }else if(nameJobRole.Text == "Use as Client")
            {
                nameJobRole.Text = "Use as Smart Buyer";

            }
        }

    */
        public void loadProfile()
        {


            Dictionary<string, object> userData = ShareUserData.getUserData;

            //  SignupBean bean2 = bal.getData();
            string imageId = "";

            name.Text = Convert.ToString(userData["fullName"]);
            email.Text = Convert.ToString(userData["email"]);
            
            imageId = Convert.ToString(userData["gdProfileImageId"]);
            if (imageId == "")
            {
                imageSource.Source = "img.png";
            }
            else
            {
                imageSource.Source = "https://drive.google.com/uc?export=view&id=" + imageId;

            }


        }

        
     


        public void view_profile(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new Profile());
        }

        public void trolli_home(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClientMainPage("asda"));
        }

    }
}