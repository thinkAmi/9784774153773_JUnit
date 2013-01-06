using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch18.ex03;

namespace test.ch18.ex03
{
    public class CounterTest
    {

        [TestFixture]
        public class 初期状態の場合
        {
            Counter sut;

            [SetUp]
            public void SetUp()
            {
                sut = new Counter();
            }

            [Test]
            public void incrementで1が取得できる()
            {
                Assert.That(sut.Increment(), Is.EqualTo(1));
            }
        }


        [TestFixture]
        public class incrementが1回実行された場合
        {
            Counter sut;

            [SetUp]
            public void SetUp()
            {
                sut = new Counter();
                sut.Increment();
            }

            [Test]
            public void incrementで2が取得できる()
            {
                Assert.That(sut.Increment(), Is.EqualTo(2));
            }
        }


        [TestFixture]
        public class incrementが50回実行された場合
        {
            Counter sut;

            [SetUp]
            public void SetUp()
            {
                sut = new Counter();

                for (int i = 0; i < 50; i++)
                {
                    sut.Increment();
                }
            }

            [Test]
            public void incrementで51が取得できる()
            {
                Assert.That(sut.Increment(), Is.EqualTo(51));
            }
        }
    }
}
