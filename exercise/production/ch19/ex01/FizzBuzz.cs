using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch19.ex01
{
    public class FizzBuzz
    {
        public static List<string> CreateFizzBuzzList(int size)
        {
            List<string> list = new List<string>();

            for (int i = 1; i <= size; i++)
            {
                if (i % 15 == 0)
                {
                    list.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    list.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    list.Add("Buzz");
                }
                else
                {
                    list.Add(i.ToString());
                }
            }

            return list;
        }
    }
}
