using OneSignalAPI.BeanClass;
using Plugin.Media;
using RealTrolli.ApiClass;
using RealTrolli.BeanClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealTrolli
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileUpdate : ContentPage
	{
		public ProfileUpdate ()
		{
			InitializeComponent ();
            
            loadProfile();
		}
        protected override bool OnBackButtonPressed()
        {

            return true;
        }
        GoogleDriveAPI googleAPI = new GoogleDriveAPI();

        string gdFolderID = "";
        public void loadProfile()
        {
            Dictionary<string, object> userData = ShareUserData.getUserData;


            txtName.Text = Convert.ToString(userData["fullName"]);
            txtEmail.Text = Convert.ToString(userData["email"]);
            txtStates.Text = Convert.ToString(userData["state"]);
            txtSuburb.Text = Convert.ToString(userData["suburb"]);
            txtPostCode.Text = Convert.ToString(userData["postCode"]);
            gdFolderID = Convert.ToString(userData["gdFolderId"]);

            imageId = Convert.ToString(userData["gdProfileImageId"]);
            if (imageId == "")
            {
                profileImage.Source = "logo2.png";
            }
            else
            {
                profileImage.Source = "https://drive.google.com/uc?export=view&id=" + imageId;

            }
            /*     GlobalVaribles bal = new GlobalVaribles();
                 SignupBean bean2 = bal.getData();


                 txtName.Text = bean2.name;
                 txtEmail.Text = bean2.email;
                 txtStates.Text = bean2.states;
                 txtSuburb.Text = bean2.subrub;
                 txtPostCode.Text = bean2.postCodes;
                 */
        }

        Dictionary<string, object> reloadData = new Dictionary<string, object>();
        string imageId = "";
        int updateImageCheck = 0;
        public async void btn_update(Object sender, EventArgs e)
        {

           // ActivityIndicator AI = new ActivityIndicator();
           // AI.IsRunning = true;
            //GlobalVaribles bal = new GlobalVaribles();
            //SignupBean bean2 = bal.getData();
            Dictionary<string, object> userData = ShareUserData.getUserData;


            string name = txtName.Text;
            string email = txtEmail.Text;
            string states = txtStates.Text;
            string suburb = txtSuburb.Text;
            string postCode = txtPostCode.Text;
            string UDID = Convert.ToString(userData["UniqueID"]); 
            string simNumber = Convert.ToString(userData["simNumber"]);
            string userType = Convert.ToString(userData["userType"]);
            //string lat = Convert.ToString(userData[""]);
           // string lng = Convert.ToString(userData[""]);
            string country = Convert.ToString(userData["country"]);
            string deviceId = Convert.ToString(userData["deviceId"]);

            string folderId = Convert.ToString(userData["gdFolderId"]);
            if (updateImageCheck == 0) {
                imageId = Convert.ToString(userData["gdProfileImageId"]);
            }


            SignupBean bean = new SignupBean
            {
                name = name,
                email = email,
                subrub = suburb,
                states = states,
                postCodes = postCode,
                country = country,
                userType = userType,
                phoneNumber = simNumber,
                deviceId = deviceId,
                latitude = "44",
                longitude = "66",
                UUID = UDID, 
                imageId = imageId,
                rewardCard1 = "",
                rewardCard2 = "",
                folderId = folderId

            };


            ApiCalling callApi = new ApiCalling();
            callApi.signupPost(bean);
            reloadData.Add("country",country);
            reloadData.Add("UniqueID",UDID);
            reloadData.Add("fullName",name);
            reloadData.Add("deviceId",deviceId);
            reloadData.Add("suburb",suburb);
            reloadData.Add("postCode",postCode);
            reloadData.Add("state",states);
            reloadData.Add("userType",userType);
            reloadData.Add("simNumber",simNumber);
            reloadData.Add("gdFolderId", folderId);
            reloadData.Add("gdRewardCard1", "");
            reloadData.Add("gdRewardCard2", "");
            reloadData.Add("email", email);
            reloadData.Add("gdProfileImageId", imageId);
           
            ShareUserData.getUserData = reloadData;

            // Application.Current.Properties["id"] = deviceId;
            //Application.Current.Properties["phoneNumber"] = simNumber;

            //  NavigationPage page = new NavigationPage(new ClientMainPage(name));
            //await Navigation.PopToRootAsync();
            //await Navigation.PushModalAsync(new ClientMainPage(name));
            //  this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count]);

            //  await Navigation.PushAsync(new ClientMainPage(name));
            // App app = Application.Current as App;
            // ClientMainPage md = (ClientMainPage)app.MainPage;
           // AI.IsRunning = false;
            await Navigation.PopModalAsync();



        }


   /*     public async void image_gallery(Object sender, EventArgs e) {
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
            });

            if (file == null)
                return;
           imageId = googleAPI.uploadImage(file.Path, gdFolderID);

         //   reloadData.Add("gdProfileImageId", imageId);
            profileImage.Source = "https://drive.google.com/uc?export=view&id="+imageId;
            updateImageCheck = 1;
            //  await DisplayAlert("File Location", file.Path, "OK");
        }
        */
        public async void image_camera(Object sender, EventArgs e) {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
               
            });

            if (file == null)
                return;

            imageId = googleAPI.uploadImage(file.Path, gdFolderID);
            profileImage.Source = "https://drive.google.com/uc?export=view&id=" + imageId;

            //reloadData.Add("gdProfileImageId", imageId);
            updateImageCheck = 1;
            //await DisplayAlert("File Location", file.Path, "OK");

        }

    }
}