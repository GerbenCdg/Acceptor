using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    public class Validator
    {
        private Acceptor acceptor { get; set; }
        internal List<Coin> ValidatorCoins { get; set; }

        internal static readonly int MAX_ACCEPTED_MONEY = 2000;

        public Validator(Acceptor a)
        {
            acceptor = a;
            ValidatorCoins = new List<Coin>();
        }

        public void InsertCoins(params Coin[] coins)
        {
            foreach(Coin coin in coins)
                {
                InsertCoin(coin);
            }
        }

        public void InsertCoin(Coin coin)
        {
            if (ValidateCoin(coin) && !acceptor.IsPurchaseFinished)
            {
                ValidatorCoins.Add(coin);
                acceptor.CheckInsertedMoney();
            }
            else
            {
                acceptor.InsertInRejectPipe(coin);
            }
        }

        internal bool ValidateCoin(Coin c)
        {
            return IsValid(c) && (int)c < MAX_ACCEPTED_MONEY;
        }
        
        internal int getCoinsValue()
        {
            int totalValue = 0;
            foreach (Coin c in ValidatorCoins){
                totalValue += (int)c;
            }
            return totalValue;
        }

        private bool IsValid(Coin c)
        {
            //TODO: Know how to actually validate a coin. 
            /*
            - Random probability of a coin not being accepted?
            - Coin not accepted if it's value is not in the enum?
             */
            return true;
        }


    }
}
