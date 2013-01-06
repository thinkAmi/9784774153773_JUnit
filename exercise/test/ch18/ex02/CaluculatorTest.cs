using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch18.ex02;

namespace test.ch18.ex02
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        [ExpectedException("System.DivideByZeroException")]
        public void Divideの第2引数に0を指定すると例外が発生する()
        {
            Calculator sut = new Calculator();
            sut.Divide(2, 0);
        }
    }
}
