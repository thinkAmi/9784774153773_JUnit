using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch19.ex04;

namespace test.ch19.ex04
{
    public class RangeTest
    {
        [TestFixture]
        public class Rangeオブジェクトを使ったテスト
        {
            [Test]
            public void Containsのテスト()
            {
                Assert.That(new Range(0.0, 10.5).Contains(-0.1), Is.False);
                Assert.That(new Range(0.0, 10.5).Contains(0.0), Is.True);
                Assert.That(new Range(0.0, 10.5).Contains(10.5), Is.True);
                Assert.That(new Range(0.0, 10.5).Contains(10.6), Is.False);

                Assert.That(new Range(-5.1, 5.1).Contains(-5.2), Is.False);
                Assert.That(new Range(-5.1, 5.1).Contains(-5.1), Is.True);
                Assert.That(new Range(-5.1, 5.1).Contains(5.1), Is.True);
                Assert.That(new Range(-5.1, 5.1).Contains(5.2), Is.False);
            }
        }



        public class DetapointsとTheoryを使ったテスト
        {
            public class Rangeが0から10_5まで
            {
                [TestFixture]
                public class かつ範囲外の場合
                {
                    Range sut;

                    [SetUp]
                    public void SetUp()
                    {
                        sut = new Range(0.0, 10.5);
                    }

                    [Datapoints]
                    public double[] values = new double[] { -0.1, 10.6 };

                    [Theory]
                    public void Containsはfalseを返す(double value)
                    {
                        Assert.That(sut.Contains(value), Is.False);
                    }
                }


                [TestFixture]
                public class かつ範囲内の場合
                {
                    Range sut;

                    [SetUp]
                    public void SetUp()
                    {
                        sut = new Range(0.0, 10.5);
                    }

                    [Datapoints]
                    public double[] values = new double[] { 0.0, 10.5 };

                    [Theory]
                    public void Containsはfalseを返す(double value)
                    {
                        Assert.That(sut.Contains(value), Is.True);
                    }
                }
            }


            public class Rangeがマイナス5_1から5_1まで
            {
                [TestFixture]
                public class かつ範囲外の場合
                {
                    Range sut;

                    [SetUp]
                    public void SetUp()
                    {
                        sut = new Range(-5.1, 5.1);
                    }

                    [Datapoints]
                    public double[] values = new double[] { -5.2, 5.2 };

                    [Theory]
                    public void Containsはfalseを返す(double value)
                    {
                        Assert.That(sut.Contains(value), Is.False);
                    }
                }


                [TestFixture]
                public class かつ範囲内の場合
                {
                    Range sut;

                    [SetUp]
                    public void SetUp()
                    {
                        sut = new Range(-5.1, 5.1);
                    }

                    [Datapoints]
                    public double[] values = new double[] { -5.1, 5.1 };

                    [Theory]
                    public void Containsはfalseを返す(double value)
                    {
                        Assert.That(sut.Contains(value), Is.True);
                    }
                }
            }
        }
    }
}
