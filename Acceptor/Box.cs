using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Box
    {
        private static readonly int MAX_CAPACITY = 500;
        private List<Coin> coins { get; set; }

        public Box()
        {
            coins = new List<Coin>();
        }

        internal void AddCoin(Coin c)
        {
            coins.Add(c);
            Debug.WriteLine("The coin " + c + " has been added to the box.");
        }

        public override string ToString()
        {
            int totalValue = 0;
            foreach (Coin c in coins)
            {
                totalValue += (int)c;
            }

            foreach (Coin c in coins)
            {
                Console.Write(c + " ");
            }
            return "The box contains " + coins.Count + " coins, which have a total value of " + totalValue
                + "\nIt's " + ((float)coins.Count()) / ((float)MAX_CAPACITY) + "% full.\n";
        }
    }
}
