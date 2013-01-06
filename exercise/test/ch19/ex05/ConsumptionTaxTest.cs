using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch19.ex05;

namespace test.ch19.ex05
{
    [TestFixture]
    public class ConsumptionTaxTest
    {
        [Datapoints]
        public static Fixture[] fixtures = new Fixture[] {
            new Fixture(5, 100, 105),
            new Fixture(5, 3000, 3150),
            new Fixture(10, 50, 55),
            new Fixture(5, 50, 52),
            new Fixture(3, 50, 51)
        };

        [Theory]
        public void Applyで消費税が加算された価格を取得できる(Fixture fixture)
        {
            ConsumptionTax sut = new ConsumptionTax(fixture.taxRate);
            string description = "when rate=" + fixture.taxRate.ToString() + ", price=" + fixture.price.ToString();

            //  3つめの引数としてstringを指定してあげると、テスト結果にある「Expected:」の一行上にstringの値が追加される
            Assert.That(sut.Apply(fixture.price), Is.EqualTo(fixture.expected), description);
        }
    }



    public class Fixture
    {
        public readonly int taxRate;
        public readonly int price;
        public readonly int expected;

        public Fixture(int taxRate, int price, int expected)
        {
            this.taxRate = taxRate;
            this.price = price;
            this.expected = expected;
        }
    }
    
}
