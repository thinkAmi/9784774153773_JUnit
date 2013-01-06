using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch18.ex03
{
    public class Counter
    {
        private int count = 0;

        public int Increment()
        {
            return ++count;
        }
    }
}
