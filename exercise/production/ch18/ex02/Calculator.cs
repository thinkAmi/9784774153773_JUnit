using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch18.ex02
{
    public class Calculator
    {
        public int Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("y is zero");
            }

            return x / y;
        }
    }
}
