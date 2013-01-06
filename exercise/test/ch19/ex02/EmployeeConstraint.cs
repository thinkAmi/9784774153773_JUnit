using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using production.ch19.ex02;

namespace test.ch19.ex02
{
    public class EmployeeConstraint : NUnit.Framework.Constraints.Constraint
    {
        private readonly Employee expected;
        private string field;
        private object expectedValue;
        private object actualValue;


        public static NUnit.Framework.Constraints.Constraint Employee(Employee expected)
        {
            return new EmployeeConstraint(expected);
        }


        public EmployeeConstraint(Employee expected)
        {
            this.expected = expected;
        }



        /// <summary>
        /// 独自検証メソッド
        /// </summary>
        /// <param name="actual"></param>
        /// <returns></returns>
        public override bool Matches(object actual)
        {
            if (expected == null)
            {
                return (actual == null);
            }

            if (!(actual is Employee))
            {
                return false;
            }

            Employee other = (Employee)actual;

            if (this.NotEquals(expected.FirstName, other.FirstName))
            {
                field = "FirstName";
                expectedValue = expected.FirstName;
                actualValue = other.FirstName;

                return false;
            }

            if (this.NotEquals(expected.LastName, other.LastName))
            {
                field = "LastName";
                expectedValue = expected.LastName;
                actualValue = other.LastName;

                return false;
            }

            if (this.NotEquals(expected.Email, other.Email))
            {
                field = "Email";
                expectedValue = expected.Email;
                actualValue = other.Email;

                return false;
            }

            return true;
        }


        /// <summary>
        /// オブジェクトが等しいかをチェックするプライベートメソッド
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool NotEquals(Object obj, Object other)
        {
            if (obj == other)
            {
                return other != null;
            }

            return !obj.Equals(other);
        }


        public override void WriteDescriptionTo(NUnit.Framework.Constraints.MessageWriter writer)
        {
            if (expected == null || field == null)
            {
                writer.WriteExpectedValue(expected);
            }
            else
            {
                writer.WriteExpectedValue(field + " is " + expectedValue);
            }
        }

        public override void WriteActualValueTo(NUnit.Framework.Constraints.MessageWriter writer)
        {
            writer.WriteActualValue(actualValue);
        }
    }
}
