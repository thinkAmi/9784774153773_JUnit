using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch19.ex03
{
    public class MultiLineString
    {
        public static string Join(params string[] lines)
        {
            if (lines == null)
            {
                return null;
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
