using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Pipe
    {
        private static readonly int MAX_CAPACITY = 100;
        public int Capacity { get; private set; }
        public Coin[] Coins = new Coin[MAX_CAPACITY];
        internal Coin coinType { get; set; }

        public Pipe(Coin c)
        {
            coinType = c;
        }

        internal bool isFull()
        {
            return MAX_CAPACITY == Capacity;
        }

        public void AddCoin(Coin c)
        {
            Capacity++;
            Coins[Capacity] = c;
        }

        public override string ToString()
        {
            return "Pipe of " + coinType.ToString() + ": " + Capacity + " on " + MAX_CAPACITY;
        }
    }
}
