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

            s.SelectProduct(3);

            Coin[] coins = { Coin.e2, Coin.e2};
            a.validator.InsertCoins(coins);

            Console.ReadKey(true);
        }
    }
}
