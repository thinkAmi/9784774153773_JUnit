using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.ch19.ex03
{
    public class MultiLineStringConstraint : NUnit.Framework.Constraints.Constraint
    {
        private readonly string expected;
        private object actualEx;
        private readonly string[] expectedLines;
        private string[] actualLines;
        private readonly string[] ls = { Environment.NewLine };


        public static NUnit.Framework.Constraints.Constraint Text(string text)
        {
            return new MultiLineStringConstraint(text);
        }



        public MultiLineStringConstraint(string expected)
        {
            this.expected = expected;

            //  改行コードは複数文字となるため、引数はchar型ではなく、string[]型のものを利用する
            //  StringSplitOptions.Noneとすることで、戻り値に空の部分文字列を含めないようにする
            expectedLines = expected.Split(ls, StringSplitOptions.None);
        }


        public override bool Matches(object actual)
        {
            this.actualEx = actual;
            if (expected == null)
            {
                return (actual == null);
            }

            if (!(actual is string))
            {
                return false;
            }

            if (expected.Equals(actual))
            {
                return true;
            }

            string actualString = (string)actual;
            actualLines = actualString.Split(ls, StringSplitOptions.None);


            return expectedLines.Equals(actualLines);
        }


        public override void WriteDescriptionTo(NUnit.Framework.Constraints.MessageWriter writer)
        {
            if (expected == null || actualEx == null)
            {
                writer.WriteExpectedValue(expected);
            }
            else
            {
                int lines = Math.Min(expectedLines.Length, actualLines.Length);
                for (int i = 0; i < lines; i++)
                {
                    string expectedLine = expectedLines[i];
                    string actualExLine = actualLines[i];
                    if (!(expectedLine.Equals(actualExLine)))
                    {
                        writer.WriteExpectedValue(expectedLine);
                        return;
                    }
                }

                writer.WriteExpectedValue("expected text is " + expectedLines.Length + " lines");
            }
        }

        public override void WriteActualValueTo(NUnit.Framework.Constraints.MessageWriter writer)
        {
            int lines = Math.Min(expectedLines.Length, actualLines.Length);
            for (int i = 0; i < lines; i++)
            {
                string expectedLine = expectedLines[i];
                string actualExLine = actualLines[i];
                if (!(expectedLine.Equals(actualExLine)))
                {
                    writer.WriteActualValue(actualExLine + ", line " + (i + 1).ToString() + Environment.NewLine + expected);
                    return;
                }


            }

            writer.WriteActualValue("actual text is " + actualLines.Length + " lines");
        }
    }
}
