using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Validator
    {
        private Acceptor a { get; set; }

        public Validator(Acceptor a)
        {
            this.a = a;
        }
        internal bool ValidateCoin(Coin c)
        {
            return IsValid(c) && a.InsertedMoney < Acceptor.MAX_ACCEPTED_MONEY;
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
