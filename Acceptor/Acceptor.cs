using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    public class Acceptor
    {
        public Validator validator { get; private set; }
        private Pipe[] pipes;
        private Box box = new Box();
        private Display display = new Display();
        private RejectPipe rejectPipe = new RejectPipe();

        public Acceptor()
        {
            validator = new Validator(this);

            pipes = new Pipe[Enum.GetValues(typeof(Coin)).Length];
            int i = 0;
            foreach (Coin c in Enum.GetValues(typeof(Coin)))
            {
                pipes[i].coinType = c;
                i++;
            }
        }

        internal void InsertCoins(Coin[] coins)
        {
            foreach (Coin coin in coins)
            {
                foreach (Pipe p in pipes)
                {
                    if (p.coinType == coin)
                    {
                        if (p.isFull())
                        {
                            p.AddCoin(coin);
                        }
                        else
                        {
                            box.AddCoin(coin);
                        }
                    }
                }
            }
        }


        internal void InsertInRejectPipe(Coin c)
        {
            rejectPipe.AddCoin(c);
        }


        private void GetState()
        {
            StringBuilder str = new StringBuilder().Append("Pipes state :");
            foreach (Pipe p in pipes)
            {
                str.Append("\n\t" + p);
            }

            str.Append("\n Box state :\n" + box);
            Console.WriteLine(str);
        }

        internal void SelectProduct(int price)
        {
            int insertedMoney = validator.getCoinsValue();
            display.DisplayMessage("Inserted money : " + ((float)price) / 100 + " | price : " + ((float)price) / 100);

            if (insertedMoney > price)
            {
                // vérifier si on est capable de rendre la monnaie
                display.DisplayMessage("You inserted enough money to buy this item.");

                if (!canGetRefunded(insertedMoney - price))
                {
                    display.DisplayMessage("... But you can only get change for ...");
                    display.DisplayMessage("You can choose to get refunded or, select another product");
                }
            }
            else
            {
                display.DisplayMessage("Please insert more money");
            }
        }

        private bool canGetRefunded(int amountToRefund)
        {
            int coinQuantity = 0;

            List<Coin> refundCoins = new List<Coin>();

            if (coinType == (int)Coin.e2)
            {
                coinQuantity = amountToRefund / 200;
                canGetRefunded(Coin.e2, coinQuantity);
            }
            if (coinType == (int)Coin.e1 || coinQuantity == 0)
            {
                coinQuantity = amountToRefund / 100;

            }
            if (coinType == (int)Coin.c50 || coinQuantity == 0)
            {
                coinQuantity = amountToRefund / 50;

            }
            if (coinType == (int)Coin.c20 || coinQuantity == 0)
            {
                coinQuantity = amountToRefund / 20;

            }
            if (coinType == (int)Coin.c10 || coinQuantity == 0)
            {
                coinQuantity = amountToRefund / 10;

            }
            if (coinType == (int)Coin.c5 || coinQuantity == 0)
            {
                coinQuantity = amountToRefund / 5;

            }


        }

        private List<Coin> canGetRefunded(Coin cointype, int quantity)
        {
            if (quantity != 0)
            {
                foreach (Pipe p in pipes)
                {
                    if ((int)p.coinType == 200)
                    {
                        if (p.Coins.Count() > quantity)
                        {
                            List<Coin> coinsList = new List<Coin>();
                            for(int i = 0; i < p.Coins.Count(); i ++)
                            {
                                coinsList.Add(cointype);
                            }
                            return new List<Coin>(){cointype, cointype};
                        }
                        else
                        {
                            canGetRefunded(200, 1);
                        }
                    }
                }

            }
        }

        public void GetRefund() // remboursement : l'achat est annulé
        {
            rejectPipe.AddCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.Clear();

            display.DisplayMessage("Thank you, Enjoy !");
        }

        public void Confirm() // effectue l'achat 
        {
            InsertCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.Clear();
        }

        private void getChange()
        {

        }


        public void MaintenanceCheck()
        {
            foreach (Pipe p in pipes)
            {
                display.DisplayMessage(p + "has been cleared and has given " + p.Clear() + "coins.");
            }

        }




    }
}
