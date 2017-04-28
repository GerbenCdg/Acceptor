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

        public Acceptor()
        {
            pipes = new Pipe[Enum.GetValues(typeof(Coin)).Length];
            int i = 0;
            foreach(Coin c in Enum.GetValues(typeof(Coin))){
                pipes[i].coinType = c;
                i++; 
            }
        }
        public void InsertCoin(Coin c)
        {
            if (validator.ValidateCoin(c))
            {
                foreach (Pipe p in pipes)
                {
                    if (p.coinType == c)
                    {
                        if (p.isFull())
                        {
                            p.AddCoin(c);
                        }
                        else
                        {
                            box.AddCoin(c);
                        }
                    }
                }
            }
        }
    }
}
