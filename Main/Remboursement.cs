using Acceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Remboursement
    {
        static void Main(string[] args)
        {

            Acceptor.Acceptor a = new Acceptor.Acceptor();

            Selector s = new Selector(a);

            a.GetState();
           // s.SelectProduct(1.99f);

            a.validator.InsertCoins(Coin.e2, Coin.e1);

            a.GetState();

          //  s.SelectProduct(5.67f);
          //  Coin[] coins2 = { Coin.e2, Coin.e2, Coin.e2 };
          //  a.validator.InsertCoins(coins2);

         //   a.GetState();

            Console.ReadKey(true);
        }
    }
}
