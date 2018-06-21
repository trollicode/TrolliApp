using RealTrolli;
using RealTrolli.ValidationClass;
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
	public partial class FirstStepRegistration : ContentPage
	{
		public FirstStepRegistration (string phone)
		{
			InitializeComponent ();
            phoneNumbers = phone;
		}


        static string phoneNumbers = "";
        public void next_button(Object sender, EventArgs e) {
            string name = "";
            string emailUser ="";

            if (checkTextField())
            {
                 name = fullName.Text;
                 emailUser = email.Text;

                Navigation.PushAsync(new CompleteRegistration(phoneNumbers, name, emailUser));
            }
        }


    

        public bool checkTextField()
        {
            bool check = true;
            string validationText = "All fields are required";

            starName.Text = " ";
           
            starEmail.Text = " ";

            if (fullName.Text == "")
            {
                starName.Text = "*";
                check = false;
            }
            RegistrationValidation.IsValidEmail(email.Text);
            if (email.Text == "" || RegistrationValidation.validation)
            {
                if (email.Text == "") { }
                else
                {
                    validationText = "Please enter a valid email";
                }
                starEmail.Text = "*";
                check = false;
            }
        
            if (!check)
            {
                validationError.Text = validationText;
                //DisplayAlert("Some Think Missing", "Text Field Missing \n" + text, "OK");
            }

            return check;

        }
    }
}