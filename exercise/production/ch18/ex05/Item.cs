using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch18.ex05
{
    public class Item
    {
        public readonly string Name;
        public readonly int Price;

        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
