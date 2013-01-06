using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch19.ex03;


namespace test.ch19.ex03
{
    [TestFixture]
    public class MultiLineStringTest
    {
        [Test]
        public void Joinで文字列が連結される()
        {
            string expected = "Hello" + Environment.NewLine + "World";
            Assert.That(MultiLineString.Join("Hello", "World"), MultiLineStringConstraint.Text(expected));
        }
    }
}
