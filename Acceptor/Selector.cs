using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    public  class Selector
    {
        private Acceptor acceptor;

        public Selector(Acceptor a)
        {
            acceptor = a;
        }

        public void Buy(float price)
        {
            acceptor.Buy( (int) price*100);
        }
    }
}
