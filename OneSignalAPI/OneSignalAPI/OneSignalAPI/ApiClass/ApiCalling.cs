using Newtonsoft.Json;
using OneSignalAPI.BeanClass;
using RealTrolli.BeanClass;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms.Internals;

namespace RealTrolli
{
    class ApiCalling
    {
        static HttpClient _client = new HttpClient();
        static HttpClient _client2 = new HttpClient();


        public async void signupPost(SignupBean ob) {
            try
            {
                await _client.PostAsync("https://trolli-194513.appspot.com/registration?fullName=" + ob.name + "&simNumber=" + ob.phoneNumber + "&suburb=" + ob.subrub + "&state=" + ob.states + "&postCode=" + ob.postCodes + "&country=" + ob.country + "&email=" + ob.email + "&userType=" + ob.userType + "&latitude=" + ob.latitude + "&longitude=" + ob.longitude + "&deviceId=" + ob.deviceId+"&UUID="+ob.UUID + "&rewardCard1=" + ob.rewardCard1+ "&rewardCard2=" + ob.rewardCard2+ "&gdFolderId="+ob.folderId+ "&imageId=" + ob.imageId, null);
            }
            catch (Exception ex) {
                Log.Warning("Error", ex.ToString());
            }
        }

        public async void isJobOnlineSeeker(IsJobOnlineSeeker ob)
        {
            try
            {
                await _client.PostAsync("https://trolli-194513.appspot.com/isOnlineJobSeeker?fullName=" + ob.fullName + "&simNumber=" + ob.simNumber+ "&isJobSeeker=" + ob.isJobSeeker, null);
            }
            catch (Exception ex){
                Log.Warning("Error", ex.ToString());
            }
        }

        public async void trollyCreation(TrollyCreation ob) 
        {
            try
            {
                await _client.PostAsync("https://trolli-194513.appspot.com/TrollyCreation?assigneeId="+ ob.assigneeId +"&clientId="+ob.clientId+"&trollyTitle="+ob.trollyTitle+"&trollyDetail="+ob.trollyDetail+"&createdDate="+ob.createdDate+"&lastModifiedDate="+ob.lastModifiedDate+"&deliveryDateTime="+ob.deliveryDateTime+"&isScheduledDelivery="+ob.isScheduledDelivery+"&status="+ob.status, null);
            }
            catch (Exception ex)
            {
                Log.Warning("Error", ex.ToString());
            }

        }

    
    }
}
