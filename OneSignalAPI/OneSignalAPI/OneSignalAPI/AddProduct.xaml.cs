using Newtonsoft.Json;
using OneSignalAPI.BeanClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        public AddProduct(string store, string storeSuburb)
        {
          
            InitializeComponent();
            this.Title = store;
            stores = store;
            storeSuburbs = storeSuburb;
            checkList();
            listProduct();
            Size.SelectedItem = "Standard";
            //autoComplete.DisplayMemberPath = "Name";


            autoComplete.DataSource = data;
            
        }

        ObservableCollection<string> data = new ObservableCollection<string>();
        static HttpClient _client = new HttpClient();
        private static string url = "https://jsonplaceholder.typicode.com/users";
        static int SizeEntryChange = 0;
        public void ChangeValueHandler(object Sender, SelectedItemChangedEventArgs e){
                if(Size.Items[Size.SelectedIndex] == "Custom Cell"){
                SizeEntryChange = 1;
                SizeEntry.IsVisible = true;
                SizeEntry.Focus();
                Size.IsVisible = false;

                }
        }


        public void EditHandler(Object sender, EventArgs e) {

        }

        public void DeleteHandler(Object sender, EventArgs e) {
            var content = (sender as MenuItem).CommandParameter as ListProduct;
            ShareUserData.addProduct.Remove(content);
        }


        public async void listProduct()
        {
          //  string itemsName = "";
         //  string content = await _client.GetStringAsync(url);
          //  List<Dictionary<string, object>> posts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);

          //  itemsName = Convert.ToString(posts[""]);

            data.Add("Apple Juice");
            data.Add("Coffee");
            data.Add("Milk");
            data.Add("Barbeque Sauce");
            data.Add("Cheery Pie Filling");
            data.Add("Chicken Noodle Soup, regular");
            data.Add("Green Beans, canned");
            data.Add("Milk Chocolate Bar");
            data.Add("Pasta, Egg Noodles");

        }

        public bool EntryValidation() {
            bool check = true;
            string errorInfo = "";
            if (autoComplete.Text == "") {
                check = false;
                errorInfo += "Please Select the Product \n";
            }
            if(Quantity.Text == "")
            {
                check = false;
                errorInfo += "Please Select the Product Quantity \n";
            }
            if (Size.SelectedIndex == -1) {
                check = false;
                errorInfo += "Please Select the Product Size\n";

            }
            if (Unit.SelectedIndex == -1) {
                check = false;
                errorInfo += "Please Select the Product Unit\n";

            }
          
            if (description.Text == "") {
                description.Text = " ";
            }

            if (check == false) {
                DisplayAlert("Please fill the mention field", errorInfo, "Ok");
            }

            return check;
        }



        string stores;
        string storeSuburbs;
        //  AutoCompleteTextView autoComplete1;


        ObservableCollection<ListProduct> list = null;
        public void add_productEvent(Object sender, EventArgs e)
        {
            if (EntryValidation())
            {
                string itemProduct = autoComplete.Text;

                int quantity = Convert.ToInt32(Quantity.Text);
                string sizes = "";
                if (SizeEntryChange == 0) {
                    sizes = Size.Items[Size.SelectedIndex];
                }
                else { sizes = SizeEntry.Text; }
                
                string unit = Unit.Items[Unit.SelectedIndex];
              //  string storeSuburbs = storeSuburb.Text;
                string descriptions = description.Text;
                ListProduct ob = new ListProduct()
                {
                    items = itemProduct,
                    unit = unit,
                    quantity = quantity,
                    size = sizes,
                    store = stores,
                    storeSuburb = storeSuburbs,
                    description = descriptions,
                    detailItem = quantity + " " + unit + " " + itemProduct + " " + sizes + " FROM " + stores

                };
                list.Add(ob);

                ShareUserData.addProduct = list;

                string item = quantity + " " + unit + " " + itemProduct + " FROM " + stores;


                autoComplete.Text = "";
               // storeSuburb.Text = "";
                description.Text = "";
                Quantity.Text = "";
                Size.IsVisible = true;
                SizeEntry.IsVisible = false;
                Size.SelectedIndex = 3;
                SizeEntryChange = 0;
                Unit.SelectedIndex = -1;

            }
            //list.Add(item);

          //  DisplayAlert("Test", itemProduct, "ok");
        }




        public void checkList() {
            if (ShareUserData.addProduct == null) {
                list = new ObservableCollection<ListProduct>();
            }
            else
            {
                list = ShareUserData.addProduct;
            }
                    
        }
        public async void saveEvent(Object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            //    string items = "";

            //          foreach (ListProduct ob in ShareUserData.addProduct)
            //        {
            //       items += ob.items +" "+ ob.store +"\n";
            //    }

            //   DisplayAlert("Items", items, "ok");


            //   Navigation.PushAsync(new ViewProductsList());
        }
    }

}
  