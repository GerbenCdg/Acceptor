using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class RejectPipe
    {
        private List<Coin> coins { get; set; }

        internal void AddCoin(Coin c)
        {
            coins.Add(c);
        }

        public void getState()
        {
            Console.WriteLine("Coins to withdraw : ");

            foreach (Coin c in coins)
            {
                Console.WriteLine(c);
            }
        }
    }
}
