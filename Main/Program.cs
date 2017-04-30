using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceptor;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {

            Acceptor.Acceptor a = new Acceptor.Acceptor();

            Selector s = new Selector(a);

            s.Buy(350);


            Coin[] coins = { (Coin)200, (Coin)100, (Coin)50};
            a.InsertCoins(coins);

            

        }
    }
}
