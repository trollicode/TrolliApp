using Com.OneSignal;
using RealTrolli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OneSignalAPI
{
	public partial class App : Application
	{
		public App ()
		{

			InitializeComponent();

            MainPage = new NavigationPage(new WelcomeTrolliPage());
            
            OneSignal.Current.StartInit("6be47d95-7a8a-4f0b-932a-6bffa9ee04ca").EndInit();
            OneSignal.Current.PromptLocation();

        }

		protected override void OnStart ()
		{
            OneSignal.Current.PromptLocation();
            // Handle when your app starts
        }

        protected override  async void OnSleep ()
		{
            // Handle when your app sleeps
            OneSignal.Current.PromptLocation();

            if (Device.RuntimePlatform == Device.iOS)
            {
              //  MainPage = new NavigationPage(new AlertPage());

            }
        }

        protected override void OnResume ()
		{
            OneSignal.Current.PromptLocation();

            // Handle when your app resumes
        }
    }
}
