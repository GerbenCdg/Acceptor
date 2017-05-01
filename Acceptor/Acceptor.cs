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
        private int selectedProductPrice;
        internal bool IsPurchaseFinished { get; private set; }

        public Acceptor()
        {
            validator = new Validator(this);

            pipes = new Pipe[Enum.GetValues(typeof(Coin)).Length];
            foreach (Coin c in Enum.GetValues(typeof(Coin)))
            {
                if (c == Coin.e2)
                {
                    pipes[0] = new Pipe(c);
                }
                if (c == Coin.e1)
                {
                    pipes[1] = new Pipe(c);
                }
                if (c == Coin.c50)
                {
                    pipes[2] = new Pipe(c);
                }
                if (c == Coin.c20)
                {
                    pipes[3] = new Pipe(c);
                }
                if (c == Coin.c10)
                {
                    pipes[4] = new Pipe(c);
                }
                if (c == Coin.c5)
                {
                    pipes[5] = new Pipe(c);
                }
            }
        }

        //Method to add coins to the pipes or to the box if the pipe is full.
        internal void InsertCoins(Coin[] coins)
        {
            foreach (Coin coin in coins)
            {
                foreach (Pipe p in pipes)
                {
                    if (p.CoinType == coin)
                    {
                        if (!p.IsFull())
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
            display.DisplayMessage("The coin " + c + " was rejected.");
            rejectPipe.AddCoin(c);
            rejectPipe.GetState();
            rejectPipe.WithDrawCoins();
        }


        public void GetState()
        {
            Console.WriteLine("\n -- ACCEPTOR'S STATE -- \n");
            StringBuilder str = new StringBuilder().Append("Pipes state :");
            foreach (Pipe p in pipes)
            {
                str.Append("\n\t" + p);
            }

            str.Append("\nBox state :\n" + box);
            Console.WriteLine(str);
        }

        internal void SelectProduct(int price)
        {
            IsPurchaseFinished = false;
            selectedProductPrice = price;
            display.DisplayMessage("Inserted money : " + ((float)validator.getCoinsValue()) / 100 + " | price : " + ((float)selectedProductPrice) / 100);
        }

        internal void CheckInsertedMoney()
        {
            int insertedMoney = validator.getCoinsValue();
            display.DisplayMessage("Inserted money : " + ((float)insertedMoney) / 100 + " | price : " + ((float)selectedProductPrice) / 100);

            if (insertedMoney >= selectedProductPrice)
            {
                // vérifier si on est capable de rendre la monnaie
                display.DisplayMessage("You inserted enough money to buy this item.");

                if (insertedMoney > selectedProductPrice)
                {
                    if (!CanGiveChange(insertedMoney - selectedProductPrice))
                    {
                        display.DisplayMessage("I can't give you the change for this item.");
                        display.DisplayMessage("You can choose to get refunded or select another product");
                    }
                    else
                    {
                        display.DisplayMessage("I will give you " + Display.DisplayAsPrice(insertedMoney - selectedProductPrice) + " of change.");
                        GiveChange(insertedMoney - selectedProductPrice);
                    }
                }
                else
                {
                    display.DisplayMessage("There's no change to be given. Please take the product. ");
                }

            }
            else
            {
                display.DisplayMessage("Please insert more money");
            }
        }


        public void GetRefund() // remboursement : l'achat est annulé
        {
            rejectPipe.AddCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.Clear();
            rejectPipe.GetState();
            rejectPipe.WithDrawCoins();

            display.DisplayMessage("Thank you! Good Bye! ");
        }

        public void Confirm() // effectue l'achat 
        {
            InsertCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.Clear();
            rejectPipe.WithDrawCoins();
        }

        public void MaintenanceCheck()
        {
            foreach (Pipe p in pipes)
            {
                display.DisplayMessage(p + "has been cleared and has given " + p.Clear() + "coins.");
            }

        }

        private bool CanGiveChange(int quantityToGive)
        {
            return GetValueInsidePipes() >= quantityToGive;
        }

        internal void GiveChange(int amountToGive)
        {
            int amountInPipe = 0;
            int numberOfCoinsToGive = 0;

            if (CanGiveChange(amountToGive))
            {
                foreach (Pipe p in pipes)
                {
                    if (amountToGive < 5)
                    {
                        display.DisplayMessage("We are sorry but we don't give back less than 5 centimes. You were robbed " + amountToGive + " centims.");
                        amountToGive = 0;
                        break;
                    }

                    if (p.CoinType == Coin.e2)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.CoinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.CoinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountToGive = amountToGive % (int)p.CoinType;
                        }
                    }

                    if (p.CoinType == Coin.e1 && amountToGive > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.CoinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.CoinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountToGive = amountToGive % (int)p.CoinType;
                        }
                    }

                    if (p.CoinType == Coin.c50 && amountToGive > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.CoinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.CoinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountToGive = amountToGive % (int)p.CoinType;
                        }
                    }


                    if (p.CoinType == Coin.c20 && amountToGive > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.CoinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.CoinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountToGive = amountToGive % (int)p.CoinType;
                        }
                    }

                    if (p.CoinType == Coin.c10 && amountToGive > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.CoinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.CoinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountToGive = amountToGive % (int)p.CoinType;
                        }
                    }

                    if (p.CoinType == Coin.c5 && amountToGive > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.CoinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.CoinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountToGive = amountToGive % (int)p.CoinType;
                        }
                    }
                }
            }

            if (amountToGive == 0)
            {
                display.DisplayMessage("You can now take your product" + (rejectPipe.HasCoins() ? " and your change. " : ". ") + "Please, come back soon! \n");
                Confirm();
                IsPurchaseFinished = true;
            }
        }

        private int GetValueInsidePipes()
        {
            int ValueInsideAllPipes = 0;
            foreach (Pipe p in pipes)
            {
                ValueInsideAllPipes += p.NumberOfCoins * (int)p.CoinType;
            }

            return ValueInsideAllPipes;
        }
    }
}
