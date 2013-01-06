using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch19.ex04
{
    public class Range
    {
        public readonly double min;
        public readonly double max;

        public Range(double min, double max)
        {
            this.min = min;
            this.max = max;
        }

        public bool Contains(double value)
        {
            return min <= value && value <= max;
        }
    }
}
