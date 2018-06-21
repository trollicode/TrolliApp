using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.OneSignal;
using Foundation;
using UIKit;

namespace OneSignalAPI.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            OneSignal.Current.StartInit("6be47d95-7a8a-4f0b-932a-6bffa9ee04ca").EndInit();
            OneSignal.Current.PromptLocation();
            new Syncfusion.SfAutoComplete.XForms.iOS.SfAutoCompleteRenderer();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            
            return base.FinishedLaunching(app, options);
        }

        public override void OnResignActivation(UIApplication uiApplication)
        {
            OneSignal.Current.PromptLocation();
            base.OnResignActivation(uiApplication);
        }
        public override async void DidEnterBackground(UIApplication uiApplication)
        {
           
            nint taskID = UIApplication.SharedApplication.BeginBackgroundTask(() => {
                OneSignal.Current.PromptLocation();

                Console.WriteLine("BackGround Event!!");
            });
            new Task(() => {
                //    OneSignal.Current.PromptLocation();

                Console.WriteLine("BackGround Event!! Task");
                UIApplication.SharedApplication.EndBackgroundTask(taskID);
            }).Start();
        }

        public override void WillTerminate(UIApplication uiApplication)
        {

            OneSignal.Current.PromptLocation();

            base.WillTerminate(uiApplication);
        }

    }
}
