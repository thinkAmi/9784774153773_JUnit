using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch19.ex02;

namespace test.ch19.ex02
{
    public class EmployeeTest
    {
        [TestFixture]
        public class フィールドごとのアサーション版
        {

            System.IO.StreamReader stream;

            [SetUp]
            public void SetUp()
            {
                string path = @".\ch19\ex02\Employee.txt";
                Encoding encode = Encoding.GetEncoding("Shift_JIS");
                stream = new System.IO.StreamReader(path, encode);
            }

            [Test]
            public void LoadでEmployeeの一覧を取得できる()
            {
                var employee = Employee.Load(stream);

                Assert.That(employee, Is.Not.Null);
                Assert.That(employee.Count, Is.EqualTo(1));

                var actual = employee.First();
                Assert.That(actual.FirstName, Is.EqualTo("Ichiro"));
                Assert.That(actual.LastName, Is.EqualTo("Tanaka"));
                Assert.That(actual.Email, Is.EqualTo("ichiro@example.com"));
            }
        }

        [TestFixture]
        public class カスタムConstraint版
        {
            System.IO.StreamReader stream;
            Employee expected;

            [SetUp]
            public void SetUp()
            {
                string path = @".\ch19\ex02\Employee.txt";
                Encoding encode = Encoding.GetEncoding("Shift_JIS");
                stream = new System.IO.StreamReader(path, encode);

                expected = new Employee();
                expected.FirstName = "Ichiro";
                expected.LastName = "Tanaka";
                expected.Email = "ichiro@example.com";
            }

            [Test]
            public void LoadでEmployeeの一覧を取得できる()
            {
                var employee = Employee.Load(stream);

                Assert.That(employee, Is.Not.Null);
                Assert.That(employee.Count, Is.EqualTo(1));
                Assert.That(employee.First(), EmployeeConstraint.Employee(expected));
            }
        }
    }
}
