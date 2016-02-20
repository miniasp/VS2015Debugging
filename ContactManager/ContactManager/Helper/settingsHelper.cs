using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    public static class settingsHelper
    {
        public static event Action OnCurrencyChanged;

        public static void ChangeCurrency()
        {
            //...
            if (OnCurrencyChanged != null)
                OnCurrencyChanged();
        }
    }
}
