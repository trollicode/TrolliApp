using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.OneSignal;
using Google.Apis.Drive.v3;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Google.Apis.Logging;
using Com.OneSignal.Abstractions;

namespace OneSignalAPI.Droid
{
    [Activity(Label = "Trolli", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

      
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            OneSignal.Current.StartInit("6be47d95-7a8a-4f0b-932a-6bffa9ee04ca").EndInit();
            OneSignal.Current.PromptLocation();
       //     new Syncfusion.SfAutoComplete.XForms.Droid.SfAutoCompleteRenderer();
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

