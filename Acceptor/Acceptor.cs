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

        public Acceptor()
        {
            validator = new Validator(this);

            pipes = new Pipe[Enum.GetValues(typeof(Coin)).Length];
            int i = 0;
            foreach (Coin c in Enum.GetValues(typeof(Coin)))
            {
                pipes[i] = new Pipe(c);
                i++;
            }
        }

        //Method to add coins to the pipes or to the box if the pipe is full.
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

                if(insertedMoney > selectedProductPrice)
                {
                    if (!CanGiveChange(insertedMoney - selectedProductPrice))
                    {
                        display.DisplayMessage("I can't give you the change for this item.");
                        display.DisplayMessage("You can choose to get refunded or select another product");
                    } else
                    {
                        display.DisplayMessage("I will give you " + (insertedMoney - selectedProductPrice)/100 + " of change.");
                        GiveChange(insertedMoney - selectedProductPrice);
                    }
                } else
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

            display.DisplayMessage("Thank you, Enjoy !");
        }

        public void Confirm() // effectue l'achat 
        {
            InsertCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.Clear();
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
            int amountMissing = amountToGive;
            int numberOfCoinsToGive = 0;

            if (CanGiveChange(amountToGive))
            {
                foreach (Pipe p in pipes)
                {
                    if (p.coinType == Coin.e2)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.coinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.coinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountMissing = amountToGive % (int)p.coinType;
                        }
                    }

                    if (p.coinType == Coin.e1 && amountMissing > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.coinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.coinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountMissing = amountToGive % (int)p.coinType;
                        }
                    }

                    if (p.coinType == Coin.c50 && amountMissing > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.coinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.coinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountMissing = amountToGive % (int)p.coinType;
                        }
                    }


                    if (p.coinType == Coin.c20 && amountMissing > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.coinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.coinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountMissing = amountToGive % (int)p.coinType;
                        }
                    }

                    if (p.coinType == Coin.c10 && amountMissing > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.coinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.coinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountMissing = amountToGive % (int)p.coinType;
                        }
                    }

                    if (p.coinType == Coin.c5 && amountMissing > 0)
                    {
                        amountInPipe = p.NumberOfCoins * (int)p.coinType;

                        if (amountInPipe >= amountToGive)
                        {
                            numberOfCoinsToGive = amountToGive / (int)p.coinType;
                            rejectPipe.AddCoins(p.GiveCoins(numberOfCoinsToGive));
                            rejectPipe.GetState();
                            amountMissing = amountToGive % (int)p.coinType;
                        }
                    }
                }
            }
        }

        private int GetValueInsidePipes()
        {
            int ValueInsideAllPipes = 0;
            foreach (Pipe p in pipes)
            {
                ValueInsideAllPipes += p.NumberOfCoins * (int)p.coinType;
            }

            return ValueInsideAllPipes;
        }

    }
}
