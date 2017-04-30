using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    public class Acceptor
    {
        internal static readonly float MAX_ACCEPTED_MONEY = 20.00f;
        internal Validator validator;
        private Pipe[] pipes;
        private Box box;
        private Display display;
        private Selector selector;
        internal float InsertedMoney { get; private set; }

        public Acceptor()
        {
            selector = new Selector(this);

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

        private void GetState()
        {
            StringBuilder str = new StringBuilder().Append("Pipes state :");
            foreach (Pipe p in pipes){
                str.Append("\n\t" + p);
            }

            str.Append("\n Box state :\n"+ box);
            Console.WriteLine(str);
        }

        internal void Buy()
        {

        }

    }
}
