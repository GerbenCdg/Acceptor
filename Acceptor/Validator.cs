using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Validator
    {
        private Acceptor acceptor { get; set; }
        internal List<Coin> ValidatorCoins { get; set; }

        internal static readonly float MAX_ACCEPTED_MONEY = 2000f;

        public Validator(Acceptor a)
        {
            acceptor = a;
        }

        public void InsertCoin(Coin coin)
        {
            if (ValidateCoin(coin))
            {
                ValidatorCoins.Add(coin);
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
