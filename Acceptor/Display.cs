using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Display
    {
        internal void DisplayMessage(string msg)
        {
            Console.WriteLine("Display: " + msg);
        }

        internal static string DisplayAsPrice(int priceInCentims)
        {
            return string.Format("{0:N2}", (float)priceInCentims / 100.0f);
        }

    }
}
