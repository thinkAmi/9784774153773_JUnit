using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch18.ex04;

namespace test.ch18.ex04
{
    [TestFixture]
    public class NumberUtilsTest
    {
        [Test]
        public void IsEvenに10でTrueを返す()
        {
            Assert.That(NumberUtils.IsEven(10), Is.True);
        }

        [Test]
        public void IsEvenに7でFalseを返す()
        {
            Assert.That(NumberUtils.IsEven(7), Is.False);
        }
    }
}
