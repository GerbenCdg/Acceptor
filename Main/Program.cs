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

            a.GetState();

            Selector s = new Selector(a);
            s.SelectProduct(0.35f);

            a.validator.InsertCoins(Coin.e2);


            a.GetState();


            Console.ReadKey(true);
        }
    }
}