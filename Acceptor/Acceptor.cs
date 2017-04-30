using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    public class Acceptor
    {
        internal Validator validator;
        private Selector selector;
        private Pipe[] pipes;
        private Box box = new Box();
        private Display display = new Display();
        private RejectPipe rejectPipe = new RejectPipe();

        public Acceptor()
        {
            validator = new Validator(this);
            selector = new Selector(this);

            pipes = new Pipe[Enum.GetValues(typeof(Coin)).Length];
            int i = 0;
            foreach (Coin c in Enum.GetValues(typeof(Coin)))
            {
                pipes[i].coinType = c;
                i++;
            }
        }

        public void InsertCoins(Coin[] coins)
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

        internal void Buy(int price)
        {
            //TODO price
            // afficher si on est capable de rendre la monnaie
            // --> veuillez rentrer plus d'argent, appuyer sur rembourser ,choisir un article d'un autre prix
            // l'achat est effectué si Confirm() est appelé.
            InsertCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.RemoveRange(0, validator.ValidatorCoins.Count());
        }

        public void GetRefund() // remboursement : l'achat est annulé
        {
            rejectPipe.AddCoins(validator.ValidatorCoins.ToArray<Coin>());
            validator.ValidatorCoins.Clear();            
        }

        public void Confirm()
        {

        }

        private void getChange()
        {

        }


        public void MaintenanceCheck()
        {
            foreach (Pipe p in pipes)
            {
                display.DisplayMessage("Pipe " + p + "has been cleared and has given " + p.Clear() + "coins.");
            }

        }




    }
}
