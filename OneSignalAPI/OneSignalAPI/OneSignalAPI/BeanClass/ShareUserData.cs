using RealTrolli.BeanClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OneSignalAPI.BeanClass
{
    class ShareUserData
    {
        public static Dictionary<string, object> getUserData { get; set; }
        public static ObservableCollection<ListProduct> addProduct { get; set; }
        public static ObservableCollection<ListStores> listStore { get; set; }
    }
}
