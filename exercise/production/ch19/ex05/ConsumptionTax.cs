using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch19.ex05
{
    public class ConsumptionTax
    {
        private readonly int rate;


        public ConsumptionTax(int rate)
        {
            this.rate = rate;
        }


        public int Apply(int price)
        {
            return price + (price * this.rate / 100);
        }
    }
}
