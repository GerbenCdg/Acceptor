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
        public int NumberOfCoins { get; private set; }
        public Coin[] Coins = new Coin[MAX_CAPACITY];
        internal Coin coinType { get; set; }

        public Pipe(Coin c)
        {
            for (int i =  0; i < 50; i++)
            {
                AddCoin(coinType);
            }
            coinType = c;
        }

        internal bool isFull()
        {
            return MAX_CAPACITY == NumberOfCoins;
        }

        internal int Clear()
        {
            int NumberOfCoinsCleared = Coins.Length;

            Array.Clear(Coins, 0, Coins.Length);

            return NumberOfCoinsCleared;
        }

        public void AddCoin(Coin c)
        {
            NumberOfCoins++;
            Coins[NumberOfCoins] = c;
        }

        internal Coin[] GiveCoins(int quantityOfCoinsToGive)
        {
            NumberOfCoins -= quantityOfCoinsToGive;
            Coin[] ReturnedCoins = new Coin[quantityOfCoinsToGive];
            for(int i=0; i < ReturnedCoins.Length; i++)
            {
                ReturnedCoins[i] = this.coinType;
            }

            return ReturnedCoins;
        }

        public override string ToString()
        {
            return "Pipe of " + coinType.ToString() + ": " + NumberOfCoins + " on " + MAX_CAPACITY;
        }


    }
}
