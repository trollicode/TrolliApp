using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OneSignalAPI.BeanClass
{
    class ListStores
    {
        public string store { get; set; }
        public string storeSuburb { get; set; }
        public bool IsVisible { get; set; }
        public ObservableCollection<ListProduct> storeItems { get; set; }
    }
}
