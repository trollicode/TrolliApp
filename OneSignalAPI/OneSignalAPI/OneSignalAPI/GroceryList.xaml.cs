using OneSignalAPI.BeanClass;
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
	public partial class GroceryList : ContentPage
	{
        string titleStore = "";
        string storeSuburb = "";
		public GroceryList (string title, string storeSuburbs)
		{
			InitializeComponent ();
            this.Title = title;
            titleStore = title;
            storeSuburb = storeSuburbs;
		}
        ObservableCollection<ListProduct> list = new ObservableCollection<ListProduct>();
        ObservableCollection<ListProduct> listItems = new ObservableCollection<ListProduct>();
        protected override void OnAppearing()
        {
            list = ShareUserData.addProduct;
            listItems.Clear();
            if (list != null)
            {
                foreach (ListProduct listData in list)
                {
                    if (listData.store == titleStore)
                    {
                        listItems.Add(listData);
                    }
                }
                listView.ItemsSource = null;
                listView.ItemsSource = listItems;
            }
            base.OnAppearing();
        }

        public void AddItems(object sender, EventArgs e) {
            Navigation.PushModalAsync(new AddProduct(titleStore, storeSuburb));

        }
        ObservableCollection<ListProduct> listProduct = new ObservableCollection<ListProduct>();

        public async void DeleteHandler(Object sender, EventArgs e){
            bool check = await DisplayAlert("", "Are you sure Delete this Item from list", "Yes", "Cancel");

            if (check)
            {
                ListProduct content = (sender as Button).CommandParameter as ListProduct;
                ShareUserData.addProduct.Remove(content);
            }

            list = ShareUserData.addProduct;
            listItems.Clear();
            if (list != null)
            {
                foreach (ListProduct listData in list)
                {
                    if (listData.store == titleStore)
                    {
                        listItems.Add(listData);
                    }
                }
                listView.ItemsSource = null;
                listView.ItemsSource = listItems;
            }

        }

    }
}