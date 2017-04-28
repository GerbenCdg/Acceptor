using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Box
    {
      public List<Coin> coins { get; set; }		

      internal void AddCoin(Coin c)	
      {		
            coins.Add(c);		
      }
    }
}
