using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    public class Acceptor
    {
        internal Validator validator;
        private Pipe[] pipes;
        private Box box;
        private Display display;
        private Selector selector;


        public void InsertCoin(Coin c)
        {
            if (validator.ValidateCoin(c))
            {
                foreach (Pipe p in pipes)
                {
                    if (p.coinType == c)
                    {
                        p.AddCoin(c);
                    }
                }
            }
        }


    }
}
