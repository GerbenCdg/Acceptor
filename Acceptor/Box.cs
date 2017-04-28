using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Box
    {
        public List<Coin> coins { get; set; }

        internal void AddCoin(Coin c)	
        {		
            coins.Add(c);		
        }

        public override string ToString()
        {
            int totalValue = 0;
            foreach(Coin c in coins){
                totalValue += (int) c;
            }
            return "The box contains "+coins.Count+" coins, which have a total value of "+ totalValue;
        }
    }
}
