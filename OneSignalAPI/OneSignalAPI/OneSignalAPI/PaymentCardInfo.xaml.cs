using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentCardInfo : ContentPage
	{
		public PaymentCardInfo ()
		{
			InitializeComponent();
		}

        public void FindSmartBuyer(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindSmartBuyer());
        }

    }
}