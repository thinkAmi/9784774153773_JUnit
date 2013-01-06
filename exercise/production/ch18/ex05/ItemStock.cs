using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch18.ex05
{
    public class ItemStock
    {
        private Dictionary<string, int> values;

        public ItemStock()
        {
            values = new Dictionary<string, int>();
        }

        public void Add(Item item)
        {
            int num = 0;
            if (values.ContainsKey(item.Name))
            {
                num = values[item.Name];
            }

            num++;
            values[item.Name] = num;
        }

        public int GetNum(Item item)
        {
            // int型のデフォルト値は0
            return values.Where(v => v.Key == item.Name).SingleOrDefault().Value;
        }
    }
}
