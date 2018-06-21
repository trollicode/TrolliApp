using Newtonsoft.Json;
using OneSignalAPI.BeanClass;
using Syncfusion.SfAutoComplete.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneSignalAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateTrolli : ContentPage
	{
		public CreateTrolli ()
		{
			InitializeComponent ();
            ListOfStore();
            autoComplete.DataSource = data;
            if (listView.ItemsSource == null)
            {
                listValidationText.Text = "There is no Selected Stroes. Please Select the store";
            }
		}

        /*   public async void selected_store(Object sender, EventArgs e) {
               string store = storePicker.Items[storePicker.SelectedIndex];
               await Navigation.PushAsync(new AddProduct(store));
           }
        */
       
        protected override void OnAppearing()
        {
            
            listView.ItemsSource = null; 
            listView.ItemsSource = ShareUserData.listStore;

            if (listView.ItemsSource == null)
            {
                listValidationText.Text = "There is no Selected Stroes";

            }
            else {
                listValidationText.Text = "";

            }
            base.OnAppearing();
         
            
        }
        public void EditHandler(Object sender, EventArgs e) {
            var b = (Button)sender;

            var relative = (AbsoluteLayout)b.ParentView;
            var viewEntry1 = (SfAutoComplete)relative.Children[2];
            viewEntry1.IsVisible = true;
            var viewEntry2 = (Entry)relative.Children[3];
            viewEntry2.IsVisible = true;
            var updateStoreBtn = (Button)relative.Children[4];
            updateStoreBtn.IsVisible = true;

           

            var labelStore1 = (Label)relative.Children[0];
            labelStore1.IsVisible = false;

            var labelStore2 = (Label)relative.Children[1];
            labelStore2.IsVisible = false;


          viewEntry1.DataSource = data;
            //listStore.IsVisible = true;
            // listStoreSuburb.IsVisible = true;
        }

        public void UpdateStoreName(Object sender, EventArgs e) {
            ObservableCollection<ListStores> listStores = ShareUserData.listStore;
            ObservableCollection<ListProduct> listProducts = ShareUserData.addProduct;
            var b = (Button)sender;

            var relative = (AbsoluteLayout)b.ParentView;
            var viewEntry1 = (SfAutoComplete)relative.Children[2];
            var viewEntry2 = (Entry)relative.Children[3];

            var labelStore1 = (Label)relative.Children[0];
            labelStore1.IsVisible = false;

            var labelStore2 = (Label)relative.Children[1];
            labelStore2.IsVisible = false;

            foreach (ListStores list in listStores)
            {
                if (labelStore1.Text == list.store)
                {
                    list.store = viewEntry1.Text;
                    if (viewEntry2.Text == "") {
                        list.storeSuburb = "(No Suburbs)";

                    }
                    else
                    {
                        list.storeSuburb = viewEntry2.Text;
                    }
                }
            }

            if (listProducts != null)
            {
                foreach (ListProduct listProduct in listProducts)
                {
                    if (labelStore1.Text == listProduct.store)
                    {
                        listProduct.store = viewEntry1.Text;
                       
                        listProduct.detailItem = listProduct.quantity + " " + listProduct.unit + " " + listProduct.items + " " + listProduct.size + " FROM " + viewEntry1.Text;

                    }
                }
            }
            ShareUserData.listStore = listStores;
            ShareUserData.addProduct = listProducts;
            viewEntry1.IsVisible = false;
            labelStore1.IsVisible = true;
            labelStore2.IsVisible = true;
            listView.ItemsSource = null;
            listView.ItemsSource = ShareUserData.listStore;

        }

        public void Discard(Object sender, EventArgs e)
        {
            ObservableCollection<ListProduct> listProducts = ShareUserData.addProduct;
            string output = "";
            foreach(ListProduct list in listProducts){
                 output += JsonConvert.SerializeObject(list) +",";
            }

            DisplayAlert("", output, "ok");
        }

        ObservableCollection<ListProduct> list = new ObservableCollection<ListProduct>();
        public async void DeleteHandler(Object sender, EventArgs e)
        {
            bool check = await DisplayAlert("", "All your grocery list under this store will also be removed. Are you sure you want to delete this store from the list?", "Yes", "Cancel");

            if (check)
            {
                ListStores content = (sender as Button).CommandParameter as ListStores;
                list = ShareUserData.addProduct;

                if (list != null)
                {
                    IEnumerable<ListProduct> obsCollection = (IEnumerable<ListProduct>)ShareUserData.addProduct;
                    var lists = new List<ListProduct>(obsCollection);
                    foreach (ListProduct listData in lists)
                    {
                        if (listData.store == content.store)
                        {
                            ShareUserData.addProduct.Remove(listData);
                        }
                    }
                }
                ShareUserData.listStore.Remove(content);
            }
            


        }
        ObservableCollection<ListStores> lists = new ObservableCollection<ListStores>();

        public void ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
          //  var storeTitle = e.SelectedItem as ListStores;
         //   Navigation.PushAsync(new GroceryList(storeTitle.store, storeTitle.storeSuburb));

        }




        public void ItemSelect(Object sender, SelectedItemChangedEventArgs e) {
           // var store = e.SelectedItem as ListStores;

             var storeTitle = e.SelectedItem as ListStores;
            Navigation.PushAsync(new GroceryList(storeTitle.store, storeTitle.storeSuburb));
         /*   if (_oldData == store)
            {
                store.IsVisible = !store.IsVisible;
            }
            else {
                if(_oldData != null) {
                    _oldData.IsVisible = false;
                }
                store.IsVisible = true;

            }
            _oldData = store;
            //        var product = e.SelectedItem as ListStores;
            listView.ItemsSource = null;
            listView.ItemsSource = ShareUserData.listStore;
          */
        }


        public void AddStore(Object sender, EventArgs e) {
            //  Navigation.PushModalAsync(new StoresAdd());
            if (ShareUserData.listStore == null) { }
            else { lists = ShareUserData.listStore; }


            string storeName = autoComplete.Text;
            bool checkStores = true;
            foreach (ListStores list in lists) {
                if (storeName == list.store) {
                    checkStores = false;
                }
            }

            if (checkStores)
            {
                string storeSuburbs = "(No Suburb)";
                if (storesSuburb.Text == "")
                {
                    storesSuburb.Text = "(No Suburb)";

                }
                else { storeSuburbs = storesSuburb.Text; }
                ListStores listData = new ListStores()
                {
                    store = storeName,
                    storeSuburb = storeSuburbs

                };
                lists.Add(listData);
                ShareUserData.listStore = lists;
            }
            else{
                DisplayAlert("", "The Store is already exist in below list", "Ok");
            }

            listView.ItemsSource = null;
            listView.ItemsSource = ShareUserData.listStore;
            autoComplete.Text = "";
            storesSuburb.Text = "";
            if (listView.ItemsSource == null)
                {
                    listValidationText.Text = "There is no Selected Stroes";

                }
                else
                {
                    listValidationText.Text = "";

                }
            
        }

        ObservableCollection<string> data = new ObservableCollection<string>();
        public void ListOfStore()
        {
            data.Add("Barneys New York");
            data.Add("Bealls (Florida)");
            data.Add("Belk");
            data.Add("The Bon-Ton");
            data.Add("Boscov's");
            data.Add("Dillard's");
            data.Add("J. C. Penney");
            data.Add("Central Park Mall");
            data.Add("Mid City Centre");

        }


        public void SaveTrolly(Object sender, EventArgs e){
            Navigation.PushAsync(new ScheduledTrolly());

        }



    }
}