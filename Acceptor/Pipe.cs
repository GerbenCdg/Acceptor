using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Pipe
    {
        private static readonly int MAX_CAPACITY = 100;

        public int NumberOfCoins { get { return mNumberOfCoins;  } private set { mNumberOfCoins = value; } }
        private int mNumberOfCoins;

        public Coin[] Coins = new Coin[MAX_CAPACITY];
        internal Coin CoinType { get; set; }

        public Pipe(Coin c)
        {
            CoinType = c;
            for (int i = 0; i < 99; i++)
            {
                AddCoin(CoinType);
            }
            Debug.WriteLine($"The pipe {this} has been constructed.");
        }

        internal bool IsFull()
        {
            return MAX_CAPACITY == NumberOfCoins;
        }

        internal int Clear()
        {
            int NumberOfCoinsCleared = Coins.Length;

            Array.Clear(Coins, 0, Coins.Length);
            Debug.WriteLine($"The pipe {this} has been cleared of {NumberOfCoinsCleared} coins");
            return NumberOfCoinsCleared;
        }

        public void AddCoin(Coin c)
        {
            Coins[NumberOfCoins] = c;
            NumberOfCoins++;
            Debug.WriteLine($"The coin {c.ToString()} has been added to the pipe {this}");
        }

        internal Coin[] GiveCoins(int quantityOfCoinsToGive)
        {
            NumberOfCoins -= quantityOfCoinsToGive;
            Coin[] ReturnedCoins = new Coin[quantityOfCoinsToGive];
            for(int i=0; i < ReturnedCoins.Length; i++)
            {
                ReturnedCoins[i] = this.CoinType;
            }
            Debug.WriteLine($"The pipe {this} has given {ReturnedCoins.Length} coins");
            return ReturnedCoins;
        }

        public override string ToString()
        {
            return "Pipe of " + CoinType.ToString() + ": " + NumberOfCoins + " / " + MAX_CAPACITY;
        }


    }
}
