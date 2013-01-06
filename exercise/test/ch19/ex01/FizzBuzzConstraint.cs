using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.ch19.ex01
{
    public class Lists
    {
        public static NUnit.Framework.Constraints.Constraint List(params object[] items)
        {
            return new ListConstraint(items);
        }

        /// <summary>
        /// カスタムConstraint (JavaのカスタムMatcher)
        /// </summary>
        public class ListConstraint : NUnit.Framework.Constraints.Constraint
        {
            private readonly object[] items;

            //  actualでは継承元と名前が競合するため、別名にする
            private List<string> actualEx;
            private int idx = 0;

            public ListConstraint(object[] items)
            {
                this.items = items;
            }


            /// <summary>
            /// 検証メソッドをオーバーライドし、独自の検証を行う
            /// </summary>
            /// <param name="actual"></param>
            /// <returns></returns>
            public override bool Matches(object actual)
            {
                if (!(actual is List<string>))
                {
                    return false;
                }

                List<string> list = (List<string>)actual;
                this.actualEx = list;
                if (list.Count != items.Length)
                {
                    return false;
                }


                foreach (var obj in list)
                {
                    object other = items[idx];

                    if (obj != null && !(obj.Equals(other)))
                    {
                        return false;
                    }
                    else if (obj == null && other != null)
                    {
                        return false;
                    }

                    idx++;
                }

                return true;
            }


            /// <summary>
            /// WriteDescriptionToをオーバーライドし、「Expected:」の内容を上書き
            /// </summary>
            /// <param name="writer"></param>
            public override void WriteDescriptionTo(NUnit.Framework.Constraints.MessageWriter writer)
            {
                writer.WriteActualValue(items[idx]);
            }

            /// <summary>
            /// WriteActualValueToをオーバーライドし、「But was:」の内容を上書き
            /// </summary>
            /// <param name="writer"></param>
            public override void WriteActualValueTo(NUnit.Framework.Constraints.MessageWriter writer)
            {
                writer.WriteActualValue(actualEx[idx] + " at index of " + idx);
            }
        }
    }
}
