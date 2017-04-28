using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceptor
{
    class Pipe
    {
        private static readonly int MAX_CAPACITY = 100;
        public int Capacity { get; private set; }

        internal bool isFull()
        {
            return MAX_CAPACITY == Capacity;
        }
    }
}
